using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using AeroLog.Backend.Models;

namespace AeroLog.Backend.Controllers
{
    public class HomeController : Controller
    {
        private AeroLogContext db = new AeroLogContext();
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles ="Admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //Get Register
        public ActionResult Register()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName");
            return View();
        }
        //Post: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User registerDetails)
        {
            if (ModelState.IsValid)
            {
                User reglog = new User();

                reglog.UserName = registerDetails.UserName;
                reglog.UserSurname = registerDetails.UserSurname;
                reglog.UserEmail = registerDetails.UserEmail;
                reglog.Password = registerDetails.Password;
                reglog.RoleID = registerDetails.RoleID;
                db.Users.Add(reglog);
                db.SaveChanges();
                ViewBag.Message = "User Details Saved.";
                return View("Login");
            }
            else
            {
                return View("Register", registerDetails);
            }
        }
        //GET Login
        public ActionResult Login()
        {
            return View();
        }
        //POST Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                var isValidUser = IsValidUser(model);
                if (isValidUser != null)
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(model.UserEmail, false);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Hatali E-Posta veya Sifre");
                    return View();
                }
            }
            else
            {
                return View(model);
            }
        }
        public User IsValidUser(User model)
        {
            User user = db.Users.Where(query => query.UserEmail.Equals(model.UserEmail) && query.Password.Equals(model.Password)).SingleOrDefault();
            if (user == null)
            {
                return null;
            }
            else
            {
                return user;
            }
        }
        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
        [Authorize(Roles ="User,Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";          

            return View();
        }
    }
}