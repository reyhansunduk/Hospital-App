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
    public class CategoryController : Controller
    {
        // GET: Category
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View(db.Category.Where(x => x.IsDelete == false).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Category Category)
        {
            Category newRole = db.Category.FirstOrDefault(x => x.Name == Category.Name && x.IsDelete == false);
            if (newRole != null)
            {
                ViewBag.mesaj = "aynı isimde role tanımlayamazsınız";
                return Redirect(Request.UrlReferrer.ToString());
            }
            newRole = new Category();
            newRole.Name = Category.Name;
            newRole.IsActive = Category.IsActive;
            db.Category.Add(newRole);
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
            Category editRole = db.Category.FirstOrDefault(x => x.Id == Id && x.IsDelete == false);
            if (editRole == null)
            {
                return RedirectToAction("Index");

            }
            return View(editRole);

        }
        [HttpPost]
        public ActionResult Edit(int Id, string Name, bool? IsActive)
        {

            Category editRole = db.Category.FirstOrDefault(x => x.Id == Id && x.IsDelete == false);
            if (editRole == null)
            {
                return RedirectToAction("Index");

            }
            Category roleControl = db.Category.FirstOrDefault(x => x.Name == Name && x.Id != Id && x.IsDelete == false);
            if (roleControl != null)
            {
                ViewBag.Mesaj = "aynı isimde role tanımlayamazsınız";
                return View(editRole);//sayfayı yeniler
            }

            editRole.Name = Name;
            if (IsActive == null)
            {
                editRole.IsActive = false;
            }
            else
            {
                editRole.IsActive = true;
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
            Category delRole = db.Category.FirstOrDefault(x => x.Id == Id);
            if (delRole == null)
            {
                return RedirectToAction("Index");
            }
            delRole.IsDelete = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}