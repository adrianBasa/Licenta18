using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecomDataBase.Models;

namespace TelecomDataBase.Controllers
{
    public class ProdusController : Controller
    {
        // GET: Produs
        public ActionResult Index()
        {
             using (AdminLoginEntities4  dbprodus = new AdminLoginEntities4 ())
                {
                return View(dbprodus.Produs.ToList());
            }
           
        }

        // GET: Produs/Details/5
        public ActionResult Details(int id)
        {
            using (AdminLoginEntities4 dbprodus = new AdminLoginEntities4())
            {
                return View(dbprodus.Produs.Where(x=>x.ID==id).FirstOrDefault());
            }
                
        }

        // GET: Produs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produs/Create
        [HttpPost]
        public ActionResult Create(Produ produs)
        {
            try
            {
                using (AdminLoginEntities4 dbprodus = new AdminLoginEntities4())
                {
                    dbprodus.Produs.Add(produs);
                    dbprodus.SaveChanges();
                }

                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produs/Edit/5
        public ActionResult Edit(int id)
        {
            using (AdminLoginEntities4 dbprodus = new AdminLoginEntities4())
            {
                return View(dbprodus.Produs.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        // POST: Produs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Produ produs)
        {
            try
            { using (AdminLoginEntities4 dbprodus = new AdminLoginEntities4())
                {
                    dbprodus.Entry(produs).State = EntityState.Modified;
                    dbprodus.SaveChanges();
                }
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produs/Delete/5
        public ActionResult Delete(int id)
        {
            using (AdminLoginEntities4 dbprodus = new AdminLoginEntities4())
            {
                return View(dbprodus.Produs.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        // POST: Produs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (AdminLoginEntities4 dbprodus = new AdminLoginEntities4()) {
                    Produ produs = dbprodus.Produs.Where(x => x.ID == id).FirstOrDefault();
                    dbprodus.Produs.Remove(produs);
                    dbprodus.SaveChanges();

                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
