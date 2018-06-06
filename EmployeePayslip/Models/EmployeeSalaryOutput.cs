using System.ComponentModel;

namespace EmployeePayslip.Models
{
	public class EmployeeSalaryOutput
    {
		#region Resonse Properties

		[DisplayName("Name")]
		public string FullName { get; set; }
		
		[DisplayName("Pay-Period")]
		public string PayPeriod { get; set; }

		[DisplayName("Gross-Income")]
		public decimal GrossIncome { get; set; }

		[DisplayName("Income-Tax")]
		public decimal IncomeTax { get; set; }

		[DisplayName("Net-Income")]
		public decimal NetIncome { get; set; }

		[DisplayName("Super-Amount")]
		public decimal SuperAmount { get; set; }

        #endregion
    }
}