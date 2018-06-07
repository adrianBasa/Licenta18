using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TelecomDataBase.Models;
using TelecomDataBase.Models.ViewModel;
using TelecomDataBase.Repositories;

namespace TelecomDataBase.Controllers
{
    public class ClientController : Controller
    {
        private IRepository repository;
        public ClientController()
        {
            this.repository = new Repository();
        }

        public ClientController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: Client
        public ActionResult Index()
        {
          
                return View(repository.GetAllClients());
        }

        // GET: Client/NotFound
        public ActionResult NotFound()
        {

            return View();

        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            return View(repository.FindClientById(id));
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View(new ClientViewModel());
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(ClientViewModel client)
        {
            try
            {
                if (IsClientValid(client))
                {
                    repository.AddClient(ConvertClientViewModelToClient(client));

                    return RedirectToAction("Index");
                }
                else
                    return View(client);
            }
            catch
            {
                return View(client);
            }
        }

        private bool IsClientValid(ClientViewModel client)
        {
            
                // Validam cu ajutorul anotatiilor
                var validationContext = new ValidationContext(client, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();

                var isValid = Validator.TryValidateObject(client, validationContext, validationResults, true);
                
            return isValid;
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
            var client = this.repository.FindClientById(id);
            if (client == null)
            {
                return RedirectToAction("NotFound");
            }
            return View("Edit", client);   
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Client client)
        {
            try
            {
                repository.SetClietStateToModified(client);

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
           
                return View(this.repository.FindClientById(id));

            
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                this.repository.DeleteClientById(id);

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
