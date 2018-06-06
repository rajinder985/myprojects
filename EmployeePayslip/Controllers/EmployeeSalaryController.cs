using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeePayslip.Models;

namespace EmployeePayslip.Controllers
{
	public class EmployeeSalaryController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult GetDetails()
		{
			EmployeeSalaryInput empInput = new EmployeeSalaryInput();
			return View(empInput);

		}

		[HttpPost]
		public ActionResult GenerateSalary(EmployeeSalaryInput emp)
		{
			return PartialView("GenerateSalary", CalculateSalary(emp));

		}
		/// <summary>
		/// It will Calculate the Salary with different tax slab
		/// </summary>
		/// <param name="objSalaryRequest"></param>
		/// <returns></returns>
		public IEnumerable<EmployeeSalaryOutput> CalculateSalary(EmployeeSalaryInput objSalaryRequest)
		{

			List<EmployeeSalaryOutput> details = new List<EmployeeSalaryOutput>();
			decimal tax = 0, taxableIncome = 0, perMonthSalary = 0;
			EmployeeSalaryOutput objSalaryResponse = null;
			try
			{
				objSalaryResponse = new EmployeeSalaryOutput();
				EvaluateTax(objSalaryRequest.GrossIncome, ref tax, taxableIncome);
				perMonthSalary = (objSalaryRequest.GrossIncome - tax) / Constant.NoOfMonths;
				objSalaryResponse.GrossIncome = objSalaryRequest.GrossIncome / Constant.NoOfMonths;
				objSalaryResponse.PayPeriod = Convert.ToString(objSalaryRequest.PayPeriod);
				objSalaryResponse.IncomeTax = tax / Constant.NoOfMonths;
				objSalaryResponse.NetIncome = objSalaryResponse.GrossIncome - objSalaryResponse.IncomeTax;
				objSalaryResponse.FullName = objSalaryRequest.FirstName + " " + objSalaryRequest.LastName;

				objSalaryResponse.SuperAmount = GetSuperAmount(objSalaryRequest.GrossIncome, objSalaryRequest.SuperRate);
				details.Add(objSalaryResponse);
				return details;
			}
			catch (Exception ex)
			{

				throw ex;
				///todo : We can log exceptions in database/file
			}
		}


		/// <summary>
		/// This method will calculare tax on grows salary provided
		/// </summary>
		/// <param name="growsSalary"></param>
		/// <param name="tax"></param>
		/// <param name="incomeTax"></param>
		public void EvaluateTax(decimal growsSalary, ref decimal tax, decimal incomeTax)
		{
			try
			{
				decimal fixedTax = 0, taxableIncome = 0, totalTax = 0;

				if (growsSalary >= 18201 && growsSalary <= 37000)
				{
					taxableIncome = growsSalary - 18200;
					totalTax = taxableIncome / 100;
				}
				else if (growsSalary >= 37001 && growsSalary <= 87000)
				{
					fixedTax = 3572;
					taxableIncome = growsSalary - 37000;
					totalTax = ((taxableIncome / 100) * (decimal) (32.5)) + fixedTax;
				}
				else if (growsSalary >= 87001 && growsSalary <= 180000)
				{
					fixedTax = 19822;
					taxableIncome = growsSalary - 87000;
					totalTax = ((taxableIncome / 100) * 37) + fixedTax;
				}
				else if (growsSalary >= 180001)
				{
					fixedTax = 54232;
					taxableIncome = growsSalary - 180000;
					totalTax = ((taxableIncome / 100) * 45) + fixedTax;
				}
				tax = totalTax;
				incomeTax = taxableIncome;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Calculate Super amount
		/// </summary>
		/// <param name="totalSalary"></param>
		/// <param name="superRate"></param>
		/// <returns></returns>
		public decimal GetSuperAmount(decimal totalSalary, decimal superRate)
		{
			return ((totalSalary / Constant.NoOfMonths) * superRate) / 100;
		}

	}
}