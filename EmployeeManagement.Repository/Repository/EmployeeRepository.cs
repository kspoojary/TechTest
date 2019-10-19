using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.Repository.Models;


namespace EmployeeManagement.Repository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeDbContext employeeDbContext;
        public EmployeeRepository()
        {
            employeeDbContext = new EmployeeDbContext();
            if (!employeeDbContext.Employee.Any())
            {
                SeedData();
            }
        }
        private void SeedData()
        {
            Employee employee = new Employee();
            employee.Name = "Neudesic";
            employee.Salary = 300000;
            employee.TaxAmount = 0;
            employee.Address = "Brookefield";
            employee.EmailId = "support@neudesic.com";
            employee.DateOfBirth = DateTime.UtcNow.AddYears(-25);
            employee.Gender = "0";
            employee.PinCode = "560087";
            employeeDbContext.Employee.Add(employee);

            Employee employee1 = new Employee();
            employee1.Name = "Technologies";
            employee1.Salary = 800000;
            employee1.TaxAmount = 140000;
            employee1.Address = "Kundalahalli";
            employee1.EmailId = "customercare@neudesic.com";
            employee1.DateOfBirth = DateTime.UtcNow.AddYears(-40);
            employee1.Gender = "1";
            employee1.PinCode = "560087";
            employeeDbContext.Employee.Add(employee1);

            employeeDbContext.SaveChanges();
        }
        public Employee AddEmployee(Employee employee)
        {
            employeeDbContext.Employee.Add(employee);
            employeeDbContext.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(int employeeId)
        {
            var employee = employeeDbContext.Employee.FirstOrDefault(e => e.Id == employeeId);
            if (employee != null)
            {
                employeeDbContext.Employee.Remove(employee);
                employeeDbContext.SaveChanges();
            }
        }

        public Employee GetEmployeeByEmail(string emailId)
        {
            return employeeDbContext.Employee.Where(e => e.EmailId == emailId).FirstOrDefault();
        }

        public Employee GetEmployeeById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return employeeDbContext.Employee.ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            var objEmp = employeeDbContext.Employee.FirstOrDefault(a=>a.Id == employee.Id);
            if (objEmp != null)
            {
                objEmp.Name = employee.Name;
                objEmp.Address = employee.Address;
                objEmp.EmailId = employee.EmailId;
                objEmp.DateOfBirth = employee.DateOfBirth;
                objEmp.Gender = employee.Gender;
                objEmp.PinCode = employee.PinCode;
                objEmp.Salary = employee.Salary;
                objEmp.TaxAmount = employee.TaxAmount;
                employeeDbContext.SaveChanges();
            }
        }

        IEnumerable<Employee> IEmployeeRepository.GetEmployees()
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeRepository.GetEmployeeById(int Id)
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeRepository.GetEmployeeByEmail(string email)
        {
            throw new NotImplementedException();
        }

       

        public void UpdateEmployee(int empId)
        {
            throw new NotImplementedException();
        }
    }
}
