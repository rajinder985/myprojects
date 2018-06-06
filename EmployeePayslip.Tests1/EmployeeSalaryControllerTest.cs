// <copyright file="EmployeeSalaryControllerTest.cs">Copyright ©  2018</copyright>
using System;
using EmployeePayslip.Controllers;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;

namespace EmployeePayslip.Controllers.Tests
{
    /// <summary>This class contains parameterized unit tests for EmployeeSalaryController</summary>
    [PexClass(typeof(EmployeeSalaryController))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestFixture]
    public partial class EmployeeSalaryControllerTest
    {
    }
}
