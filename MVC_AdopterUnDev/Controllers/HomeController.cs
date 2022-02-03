using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_AdopterUnDev.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_AdopterUnDev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //questo posso cancellarlo: controllare _layout i link et STARTUP
        public IActionResult Index()
        {
            return View();
        }
        //questo posso cancellarlo: controllare _layout i link et STARTUP
        public IActionResult Privacy()
        {
            return View();
        }
        //importante di tenerlo perché generà la pagina di 'Error'
        //altrimenti devo pevedere un Controlle che fa questo e ricreare le route e la view
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
