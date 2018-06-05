using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TelecomDataBase.Models;
using TelecomDataBase.Models.ViewModel;

namespace TelecomDataBase.Controllers
{
    public class UsersAdminController : Controller
    {
        private AdminLoginEntities db = new AdminLoginEntities();

        // GET: UsersAdmin
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: UsersAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: UsersAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserName,IsAdmin,Password")] UserViewModel user)
        {
         //   if (ModelState.IsValid) {
                using (AdminLoginEntities db = new AdminLoginEntities())
                {
                    var userDetails = db.Users.Where(x => x.UserName == user.UserName).FirstOrDefault();
                    if (userDetails != null)
                    {
                        user.LoginErrorMessage = "numele de utilizator deja exista.";

                    }
                    else
                    {
                        db.Users.Add(ConverUserViewModelToUser(user));
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
              //  }
            }
            return View(user);
        }

        private User ConverUserViewModelToUser(UserViewModel user)
        {
            var salt = Helper.GenerateSalt();
            var parolaHashata = Helper.GetHashPass(user.Password, salt);
            return new User
            {
                IsAdmin = user.IsAdmin,
                Password = parolaHashata,
                Salt = salt,
                UserName = user.UserName
            };
        }

        // GET: UsersAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: UsersAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,IsAdmin,Salt,Password")] User user)
        {
           

                if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: UsersAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: UsersAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
