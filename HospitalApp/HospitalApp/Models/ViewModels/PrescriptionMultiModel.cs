using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApp.Models.ViewModels
{
    public class PrescriptionMultiModel
    {
        public List<Procedure> Procedures { get; set; }
        public List<User> Users { get; set; }
        public List<Prescription> Prescriptions { get; set; }
        public Prescription Prescription { get; set; }
    }
}