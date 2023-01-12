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
    public class DepartmentController : Controller
    {
        // GET: Department
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View(db.Department.Where(x => x.IsDelete == false).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Department Department)
        {
            Department newDepartment = db.Department.FirstOrDefault(x => x.Name == Department.Name && x.IsDelete == false);
            if (newDepartment != null)
            {
                ViewBag.mesaj = "aynı isimde Department tanımlayamazsınız";
                return Redirect(Request.UrlReferrer.ToString());
            }
            newDepartment = new Department();
            newDepartment.Name = Department.Name;
            newDepartment.IsActive = Department.IsActive;
            db.Department.Add(newDepartment);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            if (Id == 1 || Id == 2)
            {
                return RedirectToAction("Index");
            }
            Department editDepartment = db.Department.FirstOrDefault(x => x.Id == Id && x.IsDelete == false);
            if (editDepartment == null)
            {
                return RedirectToAction("Index");

            }
            return View(editDepartment);

        }
        [HttpPost]
        public ActionResult Edit(int Id, string Name, bool? IsActive)
        {

            Department editDepartment = db.Department.FirstOrDefault(x => x.Id == Id && x.IsDelete == false);
            if (editDepartment == null)
            {
                return RedirectToAction("Index");

            }
            Department DepartmentControl = db.Department.FirstOrDefault(x => x.Name == Name && x.Id != Id && x.IsDelete == false);
            if (DepartmentControl != null)
            {
                ViewBag.Mesaj = "aynı isimde Department tanımlayamazsınız";
                return View(editDepartment);//sayfayı yeniler
            }

            editDepartment.Name = Name;
            if (IsActive == null)
            {
                editDepartment.IsActive = false;
            }
            else
            {
                editDepartment.IsActive = true;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            if (Id == 1 || Id == 2)
            {
                return RedirectToAction("Index");
            }
            Department delDepartment = db.Department.FirstOrDefault(x => x.Id == Id);
            if (delDepartment == null)
            {
                return RedirectToAction("Index");
            }
            delDepartment.IsDelete = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}