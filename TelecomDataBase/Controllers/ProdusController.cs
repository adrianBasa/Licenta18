using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecomDataBase.Models;
using TelecomDataBase.Models.ViewModel;

namespace TelecomDataBase.Controllers
{
    public class ProdusController : Controller
    {
        // GET: Produs
        public ActionResult Index()
        {
             using (AdminLoginEntities dbModel = new AdminLoginEntities())
                {
                return View(dbModel.Produs.ToList());
            }
           
        }

        // GET: Produs/Details/5
        public ActionResult Details(int id)
        {
            using (AdminLoginEntities dbModel = new AdminLoginEntities())
            {
                return View(dbModel.Produs.Where(x=>x.ID==id).FirstOrDefault());
            }
                
        }

        // GET: Produs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produs/Create
        [HttpPost]
        public ActionResult Create(ProdusViewModel produs)
        {
            try
            {
                using (AdminLoginEntities dbModel = new AdminLoginEntities())
                {
                    dbModel.Produs.Add(ConvertProdusViewModeltoProdu(produs));
                    dbModel.SaveChanges();
                }

                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private Produ ConvertProdusViewModeltoProdu(ProdusViewModel produsViewModel)
        {
            return new Produ
            {
                Descriere_Produc = produsViewModel.Descriere_Produc,
                Nume_Produs = produsViewModel.Nume_Produs,
                Pret = produsViewModel.Pret           
            };
           
        }

     
        // GET: Produs/Edit/5
        public ActionResult Edit(int id)
        {
            using (AdminLoginEntities dbModel = new AdminLoginEntities())
            {
                return View(dbModel.Produs.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        // POST: Produs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Produ produs)
        {
            try
            {
                using (AdminLoginEntities dbModel = new AdminLoginEntities())
                {
                    dbModel.Entry(produs).State = EntityState.Modified;
                    dbModel.SaveChanges();
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
            using (AdminLoginEntities dbModel = new AdminLoginEntities())
            {
                return View(dbModel.Produs.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        // POST: Produs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (AdminLoginEntities dbModel = new AdminLoginEntities()) {
                    Produ produs = dbModel.Produs.Where(x => x.ID == id).FirstOrDefault();
                    dbModel.Produs.Remove(produs);
                    dbModel.SaveChanges();

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
