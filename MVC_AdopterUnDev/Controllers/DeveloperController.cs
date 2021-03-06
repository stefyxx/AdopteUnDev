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

            /*IEnumerable<ITLang> languages = _serviceLang.Get(); // fare un for -> FARE UNA PROCEDURA STOCCATA CHE FILTRI X cATEGORY!!
            if(languages.Select(l => l.idIT.ToString())== model.Select(s => s.DevCategPrincipal))
            {
                model.Select(s => s.linguaggio = _serviceLang.Get(Int32.Parse(s.DevCategPrincipal));
            }*/
            
            return View(model);

        }

        public ActionResult Details(int id)
        {
            DeveloperDetails model = _service.Get(id).ToDetailsDev();
            if (model.DevCategPrincipal == null | model.DevCategPrincipal=="")
            {
                model.ITLabel = "";
            }
            else
            {
                //NON DIMENTICARE DI USARE 'Parse' !!!
                ITLang lang = _serviceLang.Get(Int32.Parse(model.DevCategPrincipal));
                model.ITLabel = lang.ITLabel;
            }
            //ITLang lang = _serviceLang.Get(Int32.Parse(model.DevCategPrincipal));
            //model.ITLabel = lang.ITLabel;
            return View(model);
        }

        // GET: DeveloperController/Create
        [HttpGet]
        public ActionResult Create()
        {   
            DeveloperCreate model = new DeveloperCreate();
            
            //primo modo
            IEnumerable<ITLang> languages = _serviceLang.Get();
            //model.langues = languages.ToArray(); //-> se il mio 'model.langues' é un tab di type ITLang[]

            //il secondo ha il vantaggio che [] é di taglia fissa, non modificabile! e qui' serve questo
            //ITLang[] langues = _serviceLang.Get().ToArray();
            //model.langues = langues;
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
                //riempio di nuovo il select:
                IEnumerable<ITLang> languages = _serviceLang.Get();
                collection.langues = languages;
                return View(collection);
                //return RedirectToAction(nameof(Index));
            }
        }

        // GET: DeveloperController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            DeveloperCreate dev = this._service.Get(id).ToCreateDev();
            if (dev.DevCategPrincipal == null | dev.DevCategPrincipal == "") 
            {
                dev.ITLabel="";
            }
            else {
                ITLang lang = _serviceLang.Get(Int32.Parse(dev.DevCategPrincipal));
                dev.ITLabel = lang.ITLabel;
            }

            IEnumerable<ITLang> languages = _serviceLang.Get();
            dev.langues = languages;
            return View(dev);
        }

        // POST: DeveloperController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DeveloperCreate collection)
        {
            BLL_AdopteUnDev01.Models.Developer result = this._service.Get(id);

            try
            {
                if(result is null) throw new Exception("Nessun developer con questo identificante");
                if (!ModelState.IsValid) throw new Exception();

                //ho un developer a questo idDev:
                result.DevName = collection.DevName;
                result.DevFirstName = collection.DevFirstName;
                result.DevBirthDate = collection.DevBirthDate;
                result.DevPicture = collection.DevPicture;
                result.DevMail = collection.DevMail;
                result.DevHourCost = collection.DevHourCost;
                result.DevDayCost = collection.DevDayCost;
                result.DevMonthCost = collection.DevMonthCost;
                if (collection.DevCategPrincipal == null)
                {
                    result.DevCategPrincipal = "";
                }
                else {
                    result.DevCategPrincipal = collection.DevCategPrincipal;
                }

                this._service.Update(id, result);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                //1° caso: excepion é ; nessun dev a questo id
                if (result is null) { return RedirectToAction(nameof(Index)); }

                else
                {

                    if (result.DevCategPrincipal == null | result.DevCategPrincipal == "")
                    {
                        collection.ITLabel = "";
                    }
                    else
                    {
                        ITLang lang = _serviceLang.Get(Int32.Parse(collection.DevCategPrincipal));
                        collection.ITLabel = lang.ITLabel;
                    }
                }
                IEnumerable<ITLang> languages = _serviceLang.Get();
                collection.langues = languages;

                //return View(result.ToCreateDev());
                return View(collection);
            }
        }

        // GET: DeveloperController/Delete/5
        public ActionResult Delete(int id)
        {
            DeveloperDelete model = this._service.Get(id).ToDeleteDev();
            return View(model);
        }

        // POST: DeveloperController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DeveloperDelete collection)
        {
            BLL_AdopteUnDev01.Models.Developer result = this._service.Get(id);
            try
            {
                if (result is null) throw new Exception("Nessun developer con questo identificante");
                if (!ModelState.IsValid) throw new Exception();
                if (!collection.Validate) throw new Exception("Bisogna validare la cancellazione!");

                this._service.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
