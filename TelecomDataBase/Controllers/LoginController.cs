using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecomDataBase.Models;

namespace TelecomDataBase.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(TelecomDataBase.Models.ViewModel.UserViewModel userModel)
        {
            using (AdminLoginEntities db = new AdminLoginEntities())
            {
                var userDetails = db.Users.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong user name or password.";
                    return View("Index", userModel);
                }
                else {
                    Session["userID"] = userDetails.UserId;
                    Session["UserName"] = userDetails.UserName;
                    Session["IsAdmin"] = userDetails.IsAdmin;
                    return RedirectToAction("Index", "Home");
                }
           }

            
        }

        public ActionResult LogOut()
        {
            int userID = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}