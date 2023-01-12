using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApp.Models.ViewModels
{
    public class EmployeeMultiModel
    {
        public List<Department> Departments { get; set; }
        public List<Category> Categories { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Employee> Employees { get; set; }
        public Employee Employee { get; set; }
    }
}