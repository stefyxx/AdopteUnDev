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
        private readonly IDeveloperRepository<BLL_AdopteUnDev01.Models.Developer> _service;
        private readonly IDeveloperRepository<ITLang> _serviceLang;
        public DeveloperController(IDeveloperRepository<BLL_AdopteUnDev01.Models.Developer> service, IDeveloperRepository<ITLang> serviceLang)
        {
            this._service = service;
            this._serviceLang = serviceLang;
        }

        public ActionResult Index()
        {
            IEnumerable<DeveloperList> model = this._service.Get().Select(d => d.ToListDev());
            return View(model);
        }

        public ActionResult Details(int id)
        {
            DeveloperDetails model = _service.Get(id).ToDetailsDev();
            //NON DIMENTICARE DI USARE 'Parse' !!!
            ITLang lang = _serviceLang.Get(Int32.Parse(model.DevCategPrincipal));
            model.ITLabel = lang.ITLabel;
            return View(model);
        }

        // GET: DeveloperController/Create
        [HttpGet]
        public ActionResult Create()
        {   
            //primo modo
            IEnumerable<ITLang> languages = _serviceLang.Get();
            //model.langues = languages.ToArray();

            //il secondo ha il vantaggio che [] é di taglia fissa, non modificabile! e qui' serve questo
            //ITLang[] langues = _serviceLang.Get().ToArray();
            //model.langues = langues;
            DeveloperCreate model = new DeveloperCreate();
            model.langues = languages;
            return View(model);
        }

        // POST: DeveloperController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DeveloperCreate collection)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                BLL_AdopteUnDev01.Models.Developer result = new BLL_AdopteUnDev01.Models.Developer()
                { 
                    DevName = collection.DevName,
                    DevFirstName = collection.DevFirstName,
                    DevBirthDate = collection.DevBirthDate,
                    DevPicture = collection.DevPicture,
                    DevHourCost = collection.DevHourCost,
                    DevDayCost = collection.DevDayCost,
                    DevMonthCost = collection.DevMonthCost,
                    DevMail = collection.DevMail,
                    DevCategPrincipal = collection.DevCategPrincipal
                    //DevCategPrincipal = collection.idITlang.ToString(),
                };
                //insert attende un dev di type BLL che trasformerà in type DAL nel service di BLL_Adop...
                this._service.Insert(result);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return View(collection);
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
