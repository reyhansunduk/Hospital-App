using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApp.Models
{
    public class Patient:BaseClass
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Surname { get; set; }
        public string TcNumber { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public List<PatientRegistration> PatientRegistrations { get; set; }
       
    }
}