using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace COG.WEB.Controllers
{
    public class NationalSectorController : Controller
    {
        private readonly ILogger<NationalSectorController> _logger;

        public NationalSectorController(ILogger<NationalSectorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

         public IActionResult Mining()
        {
            return View();
        }

         public IActionResult Agriculture()
        {
            return View();
        }

         public IActionResult Construction()
        {
            return View();
        }

         public IActionResult Transport()
        {
            return View();
        }

         public IActionResult ServicesExportImport()
        {
            return View();
        }

         public IActionResult TrainingDevelopment()
        {
            return View();
        }

         public IActionResult EngineeringDevelopment()
        {
            return View();
        }

         public IActionResult Energy()
        {
            return View();
        }

         public IActionResult TravelTourism()
        {
            return View();
        }

         public IActionResult Health()
        {
            return View();
        }
    }
}
