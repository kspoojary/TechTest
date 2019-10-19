using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CRUDAPI.Models;
using System.Data.SqlClient;
using EmployeeManagement.Repository.Models;
using EmployeeManagement.Repository.Repository;

namespace CRUDAPI.Controllers
{
    [RoutePrefix("Api/Employee")]
    public class EmployeeAPIController : ApiController
    {
        private IEmployeeRepository employeeRepository;
        public EmployeeAPIController(IEmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }

        [HttpGet]
        [Route("AllEmployeeDetails")]
        public IHttpActionResult GetEmployee()
        {
            try
            {
                var employees = new List<EmployeeDetail>();
                var employeeList = employeeRepository.GetEmployees();

                foreach (var employee in employeeList)
                {
                    var employeeDetail = new Employee();
                    employeeDetail.Salary = employee.Salary;
                    employeeDetail.TaxAmount = employee.TaxAmount;
                    employeeDetail.EmpName = employee.Name;
                    employeeDetail.Address = employee.Address;
                    employeeDetail.EmailId = employee.EmailId;
                    employeeDetail.DateOfBirth = employee.DateOfBirth;
                    employeeDetail.Gender = employee.Gender;
                    employeeDetail.PinCode = employee.PinCode;
                    //employees.Add(employeeDetail);
            
                }
                return Ok(employees);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetEmployeeDetailsById/{employeeId}")]
        public IHttpActionResult GetEmployeeById(string employeeId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("InsertEmployeeDetails")]
        public IHttpActionResult PostEmployee(EmployeeDetail data)
        {
            var employee = new Employee();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                employee.Name = data.EmpName;
                employee.Salary = data.Salary;
                employee.TaxAmount = GetTaxAmount(data.Salary);
                employee.Address = data.Address;
                employee.EmailId = data.EmailId;
                employee.DateOfBirth = data.DateOfBirth;
                employee.Gender = data.Gender;
                employee.PinCode = data.PinCode;
                employeeRepository.AddEmployee(employee);
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(employee);
        }

        [HttpPut]
        [Route("UpdateEmployeeDetails")]
        public IHttpActionResult PutEmployeeMaster(EmployeeDetail employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Employee data = new Employee();
                data.Address = employee.Address;
                data.DateOfBirth = employee.DateOfBirth;
                data.EmailId = employee.EmailId;
                data.Gender = employee.Gender;
                data.Id = employee.EmpId;
                data.Name = employee.EmpName;
                data.Salary = employee.Salary;
                data.TaxAmount = GetTaxAmount(employee.Salary);
                data.PinCode = employee.PinCode;
                employeeRepository.UpdateEmployee(data);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(employee);
        }
        [HttpDelete]
        [Route("DeleteEmployeeDetails")]
        public IHttpActionResult DeleteEmployeeDelete(int id)
        {
            employeeRepository.DeleteEmployee(id);
            return Ok();
        }

        /// <summary>
        /// Calculate Tax based on the salary
        /// Salary 
        ///  less than 500000 then 0% tax
        ///  greater than 500000 and less than 1000000 then 20% tax
        ///  greater than 1000000 then 30% tax
        /// </summary>
        /// <param name="salary"></param>
        /// <returns></returns>
        public decimal GetTaxAmount(decimal salary)
        {
            int sal = Decimal.ToInt32(salary);
            int taxAmount = sal * 2;
            if (salary < 500000)
            {
                taxAmount = Convert.ToInt32(salary);
            }

            if (salary < 500000 || salary < 1000000)
            {
                taxAmount += sal * 2;

                if (salary < 1000000)
                {
                    taxAmount += sal * 3;
                }
            }
            return taxAmount
;        }
    }
}
