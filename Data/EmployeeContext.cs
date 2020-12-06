using Microsoft.EntityFrameworkCore;
using EmployeesCh12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesCh12.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }
        public DbSet<Benefits> Benefits { get; set; }
        public DbSet<Department> Departments  { get; set; }
        public DbSet<DepartmentLocation> DepartmentLocations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentLocation>().HasKey(d => new { d.DepartmentID, d.LocationID });
            modelBuilder.Entity<DepartmentLocation>().HasOne(dl => dl.Department).WithMany(d => d.DepartmentLocations).HasForeignKey(dl => dl.DepartmentID);
            modelBuilder.Entity<DepartmentLocation>().HasOne(dl => dl.Location).WithMany(d => d.DepartmentLocations).HasForeignKey(dl => dl.LocationID);

            modelBuilder.Entity<Benefits>().HasOne<Employee>(p => p.Employee).WithOne(s => s.Benefits).HasForeignKey<Employee>(p => p.BenefitID);
            modelBuilder.Entity<Employee>().HasOne<Benefits>(p => p.Benefits).WithOne(s => s.Employee).HasForeignKey<Benefits>(e => e.EmployeeID);
        }
    }
}
