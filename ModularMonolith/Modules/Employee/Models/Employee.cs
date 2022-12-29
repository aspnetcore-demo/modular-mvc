using ModularMonolith.Modules.Department.Models;
using System.Data;

namespace ModularMonolith.Modules.Employee.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public int LocationID { get; set; }
    }
}
