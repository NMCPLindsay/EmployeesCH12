using System;
using System.Linq;
using EmployeesCh12.Models;

namespace EmployeesCh12.Data
{
    public class DbInitializer
    {
        public static void Initialize(EmployeeContext context)
        {
            // Look for any employees.
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            var dept = new Department[]
            {
                new Department { Name = "Accounting" },
                new Department { Name = "IT" },
                new Department { Name = "Marketing" },
                new Department { Name = "Sales" },
                new Department { Name = "Management" },
                new Department { Name = "Plant" },
                new Department { Name = "Shipping" },
                new Department { Name="Warehouse"}
            };

            foreach (Department d in dept)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var loc = new Location[]
            {
                new Location { Type = Models.Type.Headquarters, Address="2200 Park Ave", Zipcode="49696" },
                new Location { Type = Models.Type.Warehouse, Address="2200 Park Ave", Zipcode="49696" },
                new Location { Type = Models.Type.Sales, Address="2200 Park Ave", Zipcode="49696" },
                new Location { Type = Models.Type.Plant, Address="2100 Park Ave", Zipcode="49696" },
                new Location { Type = Models.Type.Plant, Address="6 Hickory Blvd.", Zipcode="49696" },
                new Location { Type = Models.Type.Satellite, Address="6 Hickory Blvd.", Zipcode="49696" }
            };

            foreach (Location l in loc)
            {
                context.Locations.Add(l);
            }
            context.SaveChanges();

            var emp = new Employee[]
            {
               new Employee { ID=1012, FirstName="Freddie", LastName="Flintstone", HireDate = DateTime.Parse("2020-09-01"), DepartmentID = 1},
               new Employee { ID=1067, FirstName="Wilma", LastName="Flintstone", HireDate = DateTime.Parse("2005-07-01"), DepartmentID = 2 },
               new Employee { ID=1098, FirstName="Barney", LastName="Rubble", HireDate = DateTime.Parse("2021-09-01"), DepartmentID = 3 },
               new Employee { ID=100, FirstName="Judy", LastName="Jetson", HireDate = DateTime.Parse("2019-02-01"), DepartmentID = 4 },
               new Employee { ID=101, FirstName="Daphne", LastName="Blake", HireDate = DateTime.Parse("2010-01-01"), DepartmentID = 5 }
            };

            foreach (Employee e in emp)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();

            var empBenefits = new Benefits[]
            {
                new Benefits {EmployeeID = 1012, Category=Category.family, Dental=true, Health=true, Vision=true, LifeIns=100000 },
                new Benefits {EmployeeID = 1067, Category=Category.none, LifeIns=100000 },
                new Benefits {EmployeeID = 100 },
                new Benefits {EmployeeID = 1098 },
                new Benefits {EmployeeID = 101, Category=Category.single, Dental=true, Health=true, Vision=true, LifeIns=50000 }
            };

            foreach (Benefits b in empBenefits)
            {
                context.Benefits.Add(b);
            }
            context.SaveChanges();

            var deptLoc = new DepartmentLocation[]
            {
                new DepartmentLocation {DepartmentID=1,LocationID=1 },
                new DepartmentLocation {DepartmentID=2,LocationID=1 },
                new DepartmentLocation {DepartmentID=3,LocationID=1 },
                new DepartmentLocation {DepartmentID=4,LocationID=1 },
                new DepartmentLocation {DepartmentID=5,LocationID=1 },
                new DepartmentLocation {DepartmentID=8,LocationID=1 },
                new DepartmentLocation {DepartmentID=6,LocationID=4 },
                new DepartmentLocation {DepartmentID=7,LocationID=5 },
                new DepartmentLocation {DepartmentID=7,LocationID=5 }
            };

            foreach (DepartmentLocation dl in deptLoc)
            {
                context.DepartmentLocations.Add(dl);
            }
            context.SaveChanges();

        }
    }
}