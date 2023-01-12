using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApp.Models.ViewModels
{
    public class UserMultiModel
    {
        public List<Category> Categories { get; set; }
        public List<User> Users { get; set; }
        public User User { get; set; }
    }
}