using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApp.Models
{
    public class Employee:BaseClass
    { //PERSONEL BİLGİLER
        public string Surname { get; set; }
        public string TcNumber { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public int DepartmentId { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public double Salary { get; set; }
        public int RoomId { get; set; }
        public int CategoryId { get; set; }
        public Room Room { get; set; }
        public Department Department { get; set; }

        public Category Category { get; set; }
        public List<PatientRegistration> PatientRegistrations { get; set; }



    }
}