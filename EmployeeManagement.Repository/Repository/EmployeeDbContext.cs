using EmployeeManagement.Repository.Models;
using EmployeeManagement.Repository.Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeManagement.Repository.Repository
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() : base("name=EmployeeEntities")
        {

        }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<Employee>(new EmployeeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }


}
