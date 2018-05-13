using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecomDataBase.Models;

namespace TelecomDataBase.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Clients.ToList());
            }
            
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Clients.Where(x=>x.Id==id).FirstOrDefault());

            }

              
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {
            try
            {  using (DbModels dbModel = new DbModels()) {

                    dbModel.Clients.Add(client);
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

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Clients.Where(x => x.Id == id).FirstOrDefault());

            }

            
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Client client)
        {
            try
            {

                using (DbModels dbModel = new DbModels())
                {
                    dbModel.Entry(client).State = EntityState.Modified;
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

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Clients.Where(x => x.Id == id).FirstOrDefault());

            }
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                using (DbModels dbModel = new DbModels())
                {
                    Client client = dbModel.Clients.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.Clients.Remove(client);
                    dbModel.SaveChanges();
                }
                    // TODO: Add delete logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
