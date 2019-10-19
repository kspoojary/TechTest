using EmployeeManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeManagement.Repository.Repository.Configuration
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("EmployeeDetails");

            HasKey(e => e.Id);
            Property(e => e.Name).HasColumnName("EmpName");
            Property(e => e.EmailId).HasColumnName("EmailId");
            Property(e => e.DateOfBirth).HasColumnName("DateOfBirth");
            Property(e => e.Address).HasColumnName("Address");
            Property(e => e.Gender).HasColumnName("Gender");
            Property(e => e.PinCode).HasColumnName("PinCode");
            Property(e => e.Salary).HasColumnName("Salary");
            Property(e => e.TaxAmount).HasColumnName("TaxAmount");

        }
    }
}
