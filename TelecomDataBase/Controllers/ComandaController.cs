using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TelecomDataBase.Models;

namespace TelecomDataBase.Controllers
{
    public class ComandaController : Controller
    {
        private AdminLoginEntities db = new AdminLoginEntities();

        // GET: Comanda
        public ActionResult Index()
        {
            var comandas = db.Comandas.Include(c => c.Client).Include(c => c.Produ);
            return View(comandas.ToList());
        }

        // GET: Comanda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comanda comanda = db.Comandas.Find(id);
            if (comanda == null)
            {
                return HttpNotFound();
            }
            return View(comanda);
        }

        // GET: Comanda/Create
        public ActionResult Create()
        {
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Nume");
            ViewBag.IdProdus = new SelectList(db.Produs, "ID", "Nume_Produs");
            return View();
        }

        // POST: Comanda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdProdus,IdClient,Cantitate")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                db.Comandas.Add(comanda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Nume", comanda.IdClient);
            ViewBag.IdProdus = new SelectList(db.Produs, "ID", "Nume_Produs", comanda.IdProdus);
            return View(comanda);
        }

        // GET: Comanda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comanda comanda = db.Comandas.Find(id);
            if (comanda == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Nume", comanda.IdClient);
            ViewBag.IdProdus = new SelectList(db.Produs, "ID", "Nume_Produs", comanda.IdProdus);
            return View(comanda);
        }

        // POST: Comanda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdProdus,IdClient,Cantitate")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comanda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Nume", comanda.IdClient);
            ViewBag.IdProdus = new SelectList(db.Produs, "ID", "Nume_Produs", comanda.IdProdus);
            return View(comanda);
        }

        // GET: Comanda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comanda comanda = db.Comandas.Find(id);
            if (comanda == null)
            {
                return HttpNotFound();
            }
            return View(comanda);
        }

        // POST: Comanda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comanda comanda = db.Comandas.Find(id);
            db.Comandas.Remove(comanda);
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
