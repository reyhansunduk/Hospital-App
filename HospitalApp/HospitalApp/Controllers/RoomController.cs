using HospitalApp.Models;
using HospitalApp.Models.Entity;
using HospitalApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalApp.Controllers
{
    [Authorize]
    public class RoomController : Controller
    {
        // GET: Room
        DataContext db = new DataContext();
        // GET: AdminRoom
        public ActionResult Index()
        {
            RoomMultiModel RoomMulti = new RoomMultiModel
            {
                Rooms = db.Room.Where(x => x.IsDelete == false).ToList(),
                Departments = db.Department.Where(x => x.IsDelete == false && x.IsActive == true).ToList()
            };
            return View(RoomMulti);
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<Department> RoomList = new List<Department>();
            RoomList = db.Department.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            return View(RoomList);
        }
        [HttpPost]
        public ActionResult Create(Room Room)
        {
            Room RoomControl = db.Room.FirstOrDefault(x => x.Name == Room.Name );
            if (RoomControl != null)
            {
                return RedirectToAction("index");
            }
            Room newRoom = new Room();
            newRoom.Capacity = Room.Capacity;
            newRoom.State = Room.State;
            newRoom.Name = Room.Name;
            newRoom.RoomPrice = Room.RoomPrice;
            newRoom.DepartmentId = Room.DepartmentId;
            newRoom.IsActive = Room.IsActive;
            db.Room.Add(newRoom);
            db.SaveChanges();


            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            RoomMultiModel RoomModel = new RoomMultiModel();
            RoomModel.Departments = db.Department.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            RoomModel.Room = db.Room.FirstOrDefault(x => x.Id == Id && x.IsDelete == false);
            if (RoomModel.Room == null)
            {
                return RedirectToAction("index");
            }
            return View(RoomModel);
        }
        [HttpPost]
        public ActionResult Edit(Room Room)
        {
            Room EditRoom = new Room();
            EditRoom = db.Room.Find(Room.Id);
            Room RoomControl = new Room();

            if (EditRoom == null)
            {
                return RedirectToAction("index");
            }
            RoomControl = db.Room.FirstOrDefault(x => x.Name == Room.Name && x.IsDelete == false && x.Id != Room.Id);
            if (RoomControl != null)
            {
                RoomMultiModel RoomModel = new RoomMultiModel()
                {
                    Departments = db.Department.Where(x => x.IsDelete == false && x.IsActive == true).ToList(),
                    Room = EditRoom
                };

                ViewBag.mesaj = "aynı kullanıcı adı yada mail kullanılamaz";
                return View(RoomModel);
            }
            EditRoom.Capacity = Room.Capacity;
            EditRoom.State = Room.State;
            EditRoom.Name = Room.Name;
            EditRoom.RoomPrice = Room.RoomPrice;
            EditRoom.DepartmentId = Room.DepartmentId;
            EditRoom.IsActive = Room.IsActive;
            db.SaveChanges();


            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {


            RoomMultiModel RoomModel = new RoomMultiModel();
            RoomModel.Departments = db.Department.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            RoomModel.Room = db.Room.FirstOrDefault(x => x.Id == id && x.IsDelete == false);
            if (RoomModel.Room == null)
            {
                return RedirectToAction("index");
            }
            return View(RoomModel);




        }
        [HttpPost]
        public ActionResult Delete(Room Room)
        {

            Room delRoom = new Room();
            delRoom = db.Room.Find(Room.Id);
            delRoom.IsDelete = true;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
