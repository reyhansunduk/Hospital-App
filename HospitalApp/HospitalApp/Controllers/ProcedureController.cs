using HospitalApp.Models;
using HospitalApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalApp.Controllers
{
    [Authorize]
    public class ProcedureController : Controller
    {
        // GET: Procedure
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            List<Procedure> procedures = new List<Procedure>();
            procedures = db.Procedure.Where(x => x.IsDelete == false).ToList();
            return View(procedures);
           
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Procedure Procedure)
        {
            Procedure CreateProcedure = new Procedure();
            CreateProcedure.Name = Procedure.Name;
            CreateProcedure.Price = Procedure.Price;
            CreateProcedure.IsActive = Procedure.IsActive;
            db.Procedure.Add(CreateProcedure);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Procedure Procedure = new Procedure();
            Procedure = db.Procedure.FirstOrDefault(x => x.Id == id);
            return View(Procedure);
        }
        [HttpPost]
        public ActionResult Edit(Procedure social)
        {
            Procedure procedure1 = new Procedure();
            procedure1 = db.Procedure.FirstOrDefault(x => x.Id == social.Id);
            procedure1.Name = social.Name;
            procedure1.Price = social.Price;
            procedure1.IsActive = social.IsActive;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Procedure Procedure = new Procedure();
            Procedure = db.Procedure.FirstOrDefault(x => x.Id == id);
            Procedure.IsDelete = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}