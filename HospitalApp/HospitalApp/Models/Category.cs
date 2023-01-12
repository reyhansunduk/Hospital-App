using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApp.Models
{
    public class Category:BaseClass
    {// DOKTOR-SEKRETER-ADMİN
      
        public List<Employee> Employees { get; set; }
        public List<User> Users { get; set; }
    }
}