using AdopteUnDev_Common.IRepositories;
using DAL_AdopteUnDev.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_AdopterUnDev.Handlers;
using MVC_AdopterUnDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_AdopterUnDev.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly IDeveloperRepository<BLL_AdopteUnDev.Models.Developer> _service;
        public DeveloperController(IDeveloperRepository<BLL_AdopteUnDev.Models.Developer> service)
        {
            this._service = service;
        }

        public ActionResult Index()
        {
            IEnumerable<DeveloperList> model = this._service.Get().Select(d => d.ToListDev());
            return View(model);
        }

        public ActionResult Details(int id)
        {
            DeveloperDetails model = _service.Get(id).ToDetailsDev();
            return View(model);
        }

        // GET: DeveloperController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeveloperController/Create
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

        // GET: DeveloperController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DeveloperController/Edit/5
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

        // GET: DeveloperController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DeveloperController/Delete/5
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
