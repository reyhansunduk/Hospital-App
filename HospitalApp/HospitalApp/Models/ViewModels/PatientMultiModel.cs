using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApp.Models.ViewModels
{
    public class PatientMultiModel
    {
        public List<User> Users { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Patient> Patients { get; set; }
        public Patient Patient { get; set; }
    }
}