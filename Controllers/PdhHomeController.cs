using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using pdh_231230796_de01.Models;

namespace pdh_231230796_de01.Controllers
{
    public class PdhHomeController : Controller
    {
        private readonly ILogger<PdhHomeController> _logger;

        public PdhHomeController(ILogger<PdhHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult PdhIndex()
        {
            return View();
        }

        public IActionResult PdhPrivacy()
        {
            return View();
        }

        public IActionResult PdhContact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
