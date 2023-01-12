using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApp.Models
{
    public class Prescription:BaseClass
    {
        public int ProcedureId { get; set; }
        public Procedure Procedure { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }


    }
}