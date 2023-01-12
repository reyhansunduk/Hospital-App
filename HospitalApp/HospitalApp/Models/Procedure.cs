using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApp.Models
{
    public class Procedure:BaseClass
    {
        public double Price { get; set; }
        public List<PatientRegistration> PatientRegistrations { get; set; }
        public List<Prescription> Prescriptions { get; set; }
    }
}