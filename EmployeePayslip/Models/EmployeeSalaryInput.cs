using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeePayslip.Models
{
	public class EmployeeSalaryInput
    {
        #region Request Properties
		[Required(ErrorMessage ="Please Enter First names")]	
        public string FirstName { get; set; }
		[Required(ErrorMessage = "Please Enter Last names")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "Please Enter Gross income")]
		public decimal GrossIncome { get; set; }
		[Required(ErrorMessage = "Please Enter Super Rate")]
		public decimal SuperRate { get; set; }
		[Required(ErrorMessage = "Please Enter Pay period date")]

		[DataType(DataType.Date)]
		public DateTime PayPeriod { get; set; }
		#endregion
	}
}