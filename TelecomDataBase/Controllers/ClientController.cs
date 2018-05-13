using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecomDataBase.Models;
using TelecomDataBase.Models.ViewModel;

namespace TelecomDataBase.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            using (AdminLoginEntities dbModel = new AdminLoginEntities())
            {
                return View(dbModel.Clients.ToList());
            }
            
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            using (AdminLoginEntities dbModel = new AdminLoginEntities())
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
        public ActionResult Create(ClientViewModel client)
        {
            try
            {  using (AdminLoginEntities dbModel = new AdminLoginEntities()) {

                    dbModel.Clients.Add(ConvertClientViewModelToClient(client));
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

        private Client ConvertClientViewModelToClient(ClientViewModel clientViewModel)
        {
            return new Client
            {
                Adresa = clientViewModel.Adresa,
                CNP_CIF = clientViewModel.CNP_CIF,
               Email = clientViewModel.Email,
               Comandas = new HashSet<Comanda>(),
               Judet = clientViewModel.Judet,
               Nume = clientViewModel.Nume,
               Oras = clientViewModel.Oras,
               Prenume = clientViewModel.Prenume,
               Telefon = clientViewModel.Telefon
            };
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            using (AdminLoginEntities dbModel = new AdminLoginEntities())
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

                using (AdminLoginEntities dbModel = new AdminLoginEntities())
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
            using (AdminLoginEntities dbModel = new AdminLoginEntities())
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

                using (AdminLoginEntities dbModel = new AdminLoginEntities())
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
