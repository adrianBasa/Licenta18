using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TelecomDataBase.Controllers;
using TelecomDataBase.Repositories;
using TelecomDataBase.Models.ViewModel;
using System.Collections.Generic;
using TelecomDataBase.Models;
using System.Web.Mvc;

namespace EvidentaClientiTest
{
    [TestClass]
    public class UnitTest1
    {
        ClientController clientcontroller;
        [TestMethod]
        public void TestClientCreateNotAddingClientWhenConditionsNotMet()
        {
            var repo = new TestRepository(GetInitialTestClients());
            int nrInitialClienti = repo.Clients.Count;

            clientcontroller = new ClientController(repo);
            ClientViewModel client = new ClientViewModel();
            client.Nume = "Adrian";
            client.Oras = "Constanta";
            client.Id = 3;

            clientcontroller.Create(client);

            Assert.AreEqual(nrInitialClienti, repo.Clients.Count);
            Assert.AreNotEqual(client.Nume, repo.Clients[repo.Clients.Count - 1].Nume);
        }

        [TestMethod]
        public void TestClientCreateAddsClientWhenFieldsSet()
        {
            var repo = new TestRepository(GetInitialTestClients());
            int nrInitialClienti = repo.Clients.Count;

            clientcontroller = new ClientController(repo);
            ClientViewModel client = new ClientViewModel();
            client.Nume = "Adrian";
            client.Oras = "Constanta";
            client.Id = 3;
            client.Adresa = "Popa Lazar 2";
            client.CNP_CIF = "1931206807753";
            client.Email = "adrian@gmail.com";
            client.Judet = "Constanta";
            client.Prenume = "Gol";
            client.Telefon = "0755702116";

            clientcontroller.Create(client);

            Assert.AreEqual(nrInitialClienti + 1, repo.Clients.Count);
            Assert.AreEqual(client.Nume, repo.Clients[repo.Clients.Count - 1].Nume);
        }

        [TestMethod]
        public void TestClientDeleteRemovesClient()
        {
            var repo = new TestRepository(GetInitialTestClients());
            int nrInitialClienti = repo.Clients.Count;

            clientcontroller = new ClientController(repo);

            var actionresult = clientcontroller.Delete(1, new System.Web.Mvc.FormCollection());

            Assert.AreEqual(nrInitialClienti - 1, repo.Clients.Count);
            Assert.AreNotEqual(1, repo.Clients[0].Id);
        }

        [TestMethod]
        public void TestClientControllerEditRedirectsToNotFoundWhenIdDoesNotExist()
        {
            var repo = new TestRepository(GetInitialTestClients());
            ClientController clientController = new ClientController(repo);
            ActionResult result = clientController.Edit(10);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult routeResult = result as RedirectToRouteResult;
            Assert.AreEqual(routeResult.RouteValues["action"], "NotFound");
        }

        [TestMethod]
        public void TestClientControllerEditHasTheModelToBeEditedWhenIdExists()
        {
            // arrange
            var repo = new TestRepository(GetInitialTestClients());
            ClientController clientController = new ClientController(repo);

            // act
            ActionResult result = clientController.Edit(1);
            var viewResult = result as ViewResult;

            // assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual("Edit", viewResult.ViewName);
        }

        public IList<Client> GetInitialTestClients()
        {
            return new List<Client>
            {
                new Client {Nume = "Ionel", Oras = "Bucuresti", Id = 1 },
                new Client {Nume = "Viorel", Oras = "Iasi", Id = 2 },
            };
        }
    }
}
