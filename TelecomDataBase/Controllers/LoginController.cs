using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;
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
                //byte[] salt = new byte[32];
                //System.Security.Cryptography.RNGCryptoServiceProvider.Create().GetBytes(salt);
                

                
                var userDetails = db.Users.Where(x => x.UserName == userModel.UserName).FirstOrDefault();
                var hashedPass = Helper.GetHashPass(userModel.Password, (byte[])userDetails.Salt);

                //  var encodedPassword = GetEncodedPassword(userModel.Password);

                if (userDetails == null || !StructuralComparisons.StructuralEqualityComparer.Equals(userDetails.Password, hashedPass) )
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