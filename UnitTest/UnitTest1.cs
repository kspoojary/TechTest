using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRUDAPI.Controllers;
using EmployeeManagement.Repository.Repository;
using Moq;
using EmployeeManagement.Repository.Models;
using CRUDAPI.Models;
using System.Web.Http;
using System.Web.Http.Results;
using System;
using System.Text.RegularExpressions;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetByIdSuccess()
        {
            var employee = new Employee { Id = 42 };
            var mockRepository = new Mock<IEmployeeRepository>();
            mockRepository.Setup(x => x.GetEmployeeById(It.IsAny<int>()))
                    .Returns(employee);
            var controller = new EmployeeAPIController(mockRepository.Object);

            IHttpActionResult actionResult = controller.GetEmployeeById("42");
            var contentResult = actionResult as OkNegotiatedContentResult<EmployeeDetail>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(42, contentResult.Content.EmpId);
        }

        [TestMethod]
        public void TestGetTaxAmount()
        {
            var mockRepository = new Mock<IEmployeeRepository>();
            var controller = new EmployeeAPIController(mockRepository.Object);
            var result = controller.GetTaxAmount(400000);
            Assert.AreEqual(0, result);
            result = controller.GetTaxAmount(800000);
            Assert.AreEqual(800000 * (decimal).2, result);
            result = controller.GetTaxAmount(1800000);
            Assert.AreEqual(1800000 * (decimal).3, result);
        }

        [TestMethod]
        public void TestAddEmployee()
        {
            var repo = new EmployeeRepository();
            Employee employee = new Employee();
            employee.Address = "address";
            employee.DateOfBirth = DateTime.UtcNow.AddYears(-25);
            employee.EmailId = "support";
            employee.Gender = "0";
            employee.Id = 125;
            employee.Name = "&^$#&$^";
            employee.Salary = 150000;
            employee.PinCode = "asdf";

            var context = new Mock<EmployeeDbContext>();
            context.Setup(x => x.SaveChanges()).Returns(1);
            try
            {
                var result = repo.AddEmployee(employee);
                bool isEmail = Regex.IsMatch(result.EmailId, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                Assert.IsTrue(isEmail);
                bool isPinCode = Regex.IsMatch(result.PinCode, @"^\d{6,}$", RegexOptions.IgnoreCase);
                Assert.IsTrue(isPinCode);
                Assert.IsTrue(Regex.IsMatch(result.Name, @"^[a-zA-Z]+$"));
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
            
        }
    }
}
