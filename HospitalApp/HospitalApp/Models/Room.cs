using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApp.Models
{
    public class Room:BaseClass
    {


        public int Capacity { get; set; }
        public string State { get; set; }
        public double RoomPrice { get; set; }

        public int DepartmentId { get; set; }
      
        public Department Department { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Patient> Patients { get; set; }



    }
}