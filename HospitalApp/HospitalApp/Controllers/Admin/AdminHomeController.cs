using HospitalApp.Models;
using HospitalApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HospitalApp.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: AdminHome
        DataContext db = new DataContext();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User User)
        {
            User userControl = new User();
            userControl = db.User.FirstOrDefault(x => x.UserName == User.UserName
              && x.Password == User.Password && x.IsDelete == false);
            if (userControl != null)
            {
                if (userControl.IsActive == false)
                {
                    ViewBag.Mesaj = " bu kullanıcı actif değil ";
                    return View();
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(userControl.UserName, true);
                    if (userControl.CategoryId == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return Redirect("~/Home/Index");
                    }
                }

            }
            else
            {
                ViewBag.Mesaj = " kullanıcı adı ve şifre hatalı tekrar deneyiniz";
                return View();
            }

        }
    }
}