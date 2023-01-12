using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApp.Models.ViewModels
{
    public class RoomMultiModel
    {
        public List<Department> Departments { get; set; }
        public List<Room> Rooms { get; set; }
        public Room Room { get; set; }
    }
}