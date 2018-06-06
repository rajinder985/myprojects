using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayslip;
using EmployeePayslip.Controllers;

namespace EmployeePayslip.Tests.Controllers
{
	[TestClass]
	public class EmployeeSalaryControllerTest
	{
		[TestMethod]
		public void Index()
		{
			
			EmployeeSalaryController controller = new EmployeeSalaryController();
			ViewResult result = controller.Index() as ViewResult;
			Assert.IsNotNull(result);
		}

		
	}
}
