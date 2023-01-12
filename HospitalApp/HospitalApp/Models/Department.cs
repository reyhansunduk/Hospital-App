using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApp.Models
{
    public class Department : BaseClass
        //KBB GÖZ VB.
    {
       
        public List<Employee> Employees { get; set; }
        public List<Room> Rooms { get; set; }
    }
}