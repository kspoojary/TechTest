using System;

namespace EmployeeManagement.Repository.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
        public decimal Salary { get; set; }
        public decimal TaxAmount { get; set; }
        public string EmpName { get; set; }
    }
}
