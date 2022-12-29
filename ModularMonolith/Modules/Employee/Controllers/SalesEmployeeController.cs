using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModularMonolith.Modules.Employee.Controllers
{
    [Area("Employee")]
    public class SalesEmployeeController : Controller
    {
        private Models.Employee[] employees = 
            new Models.Employee[] { 
                new Models.Employee
                {
                    ID = 1,
                    Name = "Robert",
                    Designation="Manager",
                    LocationID=1
                },
                new Models.Employee
                {
                    ID = 2,
                    Name = "Steve",
                    Designation="Developer",
                    LocationID=1
                },
                new Models.Employee
                {
                    ID = 3,
                    Name = "Rajan",
                    Designation="CEO",
                    LocationID=2
                },
        };
        
        public IActionResult Index() {
            return View(employees.ToArray());
        }

        public IActionResult GetEmployeeListByLocation(int locationID)
        {
            Models.Employee[] empList;
            empList = this.employees.Where(item => item.LocationID == locationID).ToArray();
            return View(empList);
        }
    }
}
