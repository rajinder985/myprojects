using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayslip.Controllers;

namespace EmployeePayslip.Tests.Controllers
{
	[TestClass]
	public class EmployeeSalaryControllerTest
	{
		private decimal annualGrossIncome = 0;
		private readonly EmployeeSalaryController emplyee_controller = new EmployeeSalaryController();
		

		/// <summary>
		/// It will just validate super rate by passing zero as super rate
		/// </summary>
		[TestMethod]
		public void ValidateSuperRate()
		{
			decimal superRate = decimal.Zero;
			annualGrossIncome = 25000;			
			decimal superAmount = emplyee_controller.GetSuperAmount(annualGrossIncome, superRate);

			//It should be 0 as we are passing 0 as super amount.
			Assert.IsTrue(superAmount == 0);
		}

		/// <summary>
		/// It will calculate actual super amount and we will compare it with the actual value of super amount
		/// </summary>
		[TestMethod]
		public void CalculateActualSuperAmount()
		{
			decimal superRate = 7;
			annualGrossIncome = 210000;
			decimal superAmount = emplyee_controller.GetSuperAmount(annualGrossIncome, superRate);

			//It should be not null and equal to 1225M
			Assert.AreNotEqual(null, superAmount);
			Assert.AreEqual(1225M, superAmount);
		}


		/// <summary>
		/// Validating view result
		/// </summary>
		[TestMethod]
		public void Index()
		{
			
			EmployeeSalaryController controller = new EmployeeSalaryController();
			ViewResult result = controller.Index() as ViewResult;
			Assert.IsNotNull(result);
		}


		/// <summary>
		/// Taxable income      =  0 – $18,200     
		//  Tax on this income  =  Nil
		/// </summary>
			[TestMethod]
			public void ValidateFirstNullTaxSlab()
			{
				annualGrossIncome = 12450;
				decimal tax = 0,taxableIncome = 0;
				emplyee_controller.EvaluateTax(annualGrossIncome, ref tax, ref taxableIncome);
				Assert.AreEqual(tax, taxableIncome);
			}


		/// <summary>
		/// Taxable income      =  $18,201 – $37,000  
		//  Tax on this income  =  19c for each $1 over $18,200
		/// </summary>
			[TestMethod]
			public void ValidateTaxableIncomeForSecondSlabWithNull()
			{
				decimal tax = 0, taxableIncome = 0;
				annualGrossIncome = 21000;
				emplyee_controller.EvaluateTax(annualGrossIncome, ref tax, ref taxableIncome);

				//It should not be null
				Assert.IsNotNull(tax);
			}



		/// <summary>
		/// Taxable income      =  $37,001 – $87,000
		//  Tax on this income  =  $3,572 plus 32.5c for each $1 over $37,000
		/// </summary>
			[TestMethod]
			public void ValidateThirdTaxSlab()
			{
				decimal tax = 0, taxableIncome = 0;
				decimal baseTax = 4536;
				annualGrossIncome = 35000;				
			
				emplyee_controller.EvaluateTax(annualGrossIncome, ref tax, ref taxableIncome);

				// It should not be equal to any defined basetax
				Assert.AreNotEqual(tax, baseTax);
			}


		/// <summary>
		/// Taxable income      = $87,001 – $180,000
		//  Tax on this income  = $19,822 plus 37c for each $1 over $87,000
		/// </summary>

			[TestMethod]
			public void ValdidateTaxForthTaxSlab()
			{
				decimal baseTax = 16234;
				annualGrossIncome = 81500;
				decimal tax = 0,taxableIncome = 0;
							
				emplyee_controller.EvaluateTax(annualGrossIncome, ref tax, ref taxableIncome);

				Assert.AreEqual(18034.5M, tax);
				Assert.AreNotEqual(tax, baseTax);
		}

		/// <summary>
		/// Taxable income      = $180,001 and over
		//  Tax on this income  =  $54,232 plus 45c for each $1 over $180,000
		/// </summary>

			[TestMethod]
			public void ValidateTaxForFifthTaxSlab()
			{
				decimal baseTax   = 62350;
				annualGrossIncome = 210000;
				decimal tax = 0, taxableIncome = 0;
			
				emplyee_controller.EvaluateTax(annualGrossIncome, ref tax, ref taxableIncome);

				Assert.AreEqual(67732M, tax);
				Assert.AreNotEqual(tax, baseTax);
		}			
	}
}

