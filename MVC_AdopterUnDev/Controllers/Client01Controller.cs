using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdopteUnDev_Common.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_AdopterUnDev.Models;

namespace MVC_AdopterUnDev.Controllers
{
    public class Client01Controller : Controller
    {
        private readonly IDeveloperRepository<BLL_AdopteUnDev01.Models.Client> _serviceCl;
        public Client01Controller(IDeveloperRepository<BLL_AdopteUnDev01.Models.Client> serviceCl)
        {
            this._serviceCl = serviceCl;
        }

        // cadi sulla pag dove hai o login o registrati: vista parziale di action Login
        public ActionResult Index()
        {
            return View();
            //return PartialView(); //ritorna solo view 'index.cshtml' SENZA _layout
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ClientIndex collection)
        {

            try
            {
                //if (result is null) throw new Exception("Nessun developer con questo identificante");
                if (!ModelState.IsValid) throw new Exception();
                if (!collection.Validate) throw new Exception("Bisogna validare la cancellazione!");

                return RedirectToAction(nameof(Index), "Developer");

            }
            catch (Exception)
            {

                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ClientLogin collection)
        {
            try
            {
                return RedirectToAction("Index", "Developer");
            }
            catch (Exception)
            {

                throw;
            }
        }





        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        //NON dimenticare che non cancella i clienti; ma loro 'login' e 'psw' !!
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
