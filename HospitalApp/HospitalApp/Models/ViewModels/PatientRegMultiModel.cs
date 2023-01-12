using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApp.Models.ViewModels
{
    public class PatientRegMultiModel
    {
        public List<Patient> Patients { get; set; }
        public List<User> Users { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Procedure> Procedures { get; set; }
        public List<PatientRegistration> PatientRegistrations { get; set; }
        public PatientRegistration PatientRegistration { get; set; }
    }
}