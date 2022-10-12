using Dependency.Interface;
using Dependency.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace Dependency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IScoped _scoped;
        private readonly ISingleton _singleton;
        private readonly ITransient _transient;


        public HomeController(ILogger<HomeController> logger, IScoped data, 
            ISingleton singleton, ITransient transient)
        {
            _logger = logger;
            _scoped = data;
            _singleton = singleton;
            _transient = transient; 
        }

        public IActionResult Index()
        {
            GetCustomerGuid();
            return View();
        }

        public IActionResult Privacy()
        {
            GetCustomerGuid();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult GetCustomerGuid()
        {
            string scopedGuid = _scoped.OperationId;
            string singleTonGuid = _singleton.OperationId;
            string transientGuid = _transient.OperationId;
            return View();
        }
    }
}