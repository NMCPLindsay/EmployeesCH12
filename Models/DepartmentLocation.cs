using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesCh12.Models
{
    public class DepartmentLocation
    {
        public int DepartmentID { get; set; }
        public int LocationID { get; set; }
        public Department Department { get; set; }
        public Location Location { get; set; }
    }
}
