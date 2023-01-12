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
    public class AdminUserController : Controller
    {
        DataContext db = new DataContext();
        // GET: AdminUser
        public ActionResult Index()
        {
            UserMultiModel userMulti = new UserMultiModel
            {
                Users = db.User.Where(x => x.IsDelete == false).ToList(),
                Categories = db.Category.Where(x => x.IsDelete == false && x.IsActive==true).ToList()
            };
            return View(userMulti);
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<Category> roleList = new List<Category>();
            roleList = db.Category.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            return View(roleList);
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            User userControl = db.User.FirstOrDefault(x => x.UserName == user.UserName || x.Email == user.Email);
            if (userControl != null)
            {
                return RedirectToAction("index");
            }
            User newUSer = new User();
            newUSer.UserName = user.UserName;
            newUSer.Email = user.Email;
            newUSer.Name = user.Name;
            newUSer.Surname = user.Surname;
            newUSer.Password = user.Password;
            newUSer.BirthDay = user.BirthDay;
            newUSer.Phone = user.Phone;
            newUSer.CategoryId = user.CategoryId;
            newUSer.IsActive = user.IsActive;
            db.User.Add(newUSer);
            db.SaveChanges();


            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            UserMultiModel userModel = new UserMultiModel();
            userModel.Categories = db.Category.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            userModel.User = db.User.FirstOrDefault(x => x.Id == Id && x.IsDelete == false);
            if (userModel.User == null)
            {
                return RedirectToAction("index");
            }
            return View(userModel);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            User EditUser = new User();
            EditUser = db.User.Find(user.Id);
            User userControl = new User();

            if (EditUser == null)
            {
                return RedirectToAction("index");
            }
            userControl = db.User.FirstOrDefault(x => x.UserName == user.UserName ||
            x.Email == user.Email && x.IsDelete == false && x.Id != user.Id);
            if (userControl != null)
            {
                UserMultiModel userModel = new UserMultiModel()
                {
                    Categories = db.Category.Where(x => x.IsDelete == false && x.IsActive == true).ToList(),
                    User = EditUser
                };

                ViewBag.mesaj = "aynı kullanıcı adı yada mail kullanılamaz";
                return View(userModel);
            }
            EditUser.UserName = user.UserName;
            EditUser.Email = user.Email;
            EditUser.Name = user.Name;
            EditUser.Surname = user.Surname;
            EditUser.CategoryId = user.CategoryId;
            EditUser.BirthDay = user.BirthDay;
            EditUser.Phone = user.Phone;
            EditUser.Password = user.Password;
            EditUser.IsActive = user.IsActive;
            db.SaveChanges();


            return RedirectToAction("index");
        }
    }
}