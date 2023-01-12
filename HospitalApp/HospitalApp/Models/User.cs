using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApp.Models
{
    public class User:BaseClass
    {
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Patient> Patients { get; set; }
        public List<PatientRegistration> PatientRegistrations { get; set; }
        public List<Prescription> Prescriptions { get; set; }




    }
}