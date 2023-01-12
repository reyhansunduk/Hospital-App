using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApp.Models
{
    public class PatientRegistration
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int EmployeeId { get; set; }
        public int ProcedureId { get; set; }
        public double TotalPrice { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateHour { get; set; }
        public int UserId { get; set; }
        public Patient Patient { get; set; }
        public Employee Employee { get; set; }
        public User User { get; set; }
        public Procedure Procedure { get; set; }


    }
}