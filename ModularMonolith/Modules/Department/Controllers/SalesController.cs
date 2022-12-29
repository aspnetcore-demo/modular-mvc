using ModularMonolith.Modules.Department.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModularMonolith.Modules.Department.Controllers
{
    [Area("Department")]
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            Location[] salesLocation = new Location[] {
                new Location 
                { 
                    ID = 1, 
                    Address = "A Road",
                    City = "Pune"                    
                },
                new Location
                {
                    ID = 2,
                    Address = "B Road",
                    City = "London"
                },
                new Location
                {
                    ID = 3,
                    Address = "K Road",
                    City = "New York"
                },
            };
            return View(salesLocation);
        }
    }
}
