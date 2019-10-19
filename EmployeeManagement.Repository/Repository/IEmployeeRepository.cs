using EmployeeManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Repository.Repository;

namespace EmployeeManagement.Repository.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(int Id);
        Employee GetEmployeeByEmail(string email);
        Employee AddEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
        void UpdateEmployee(Employee employee);

    }
}
