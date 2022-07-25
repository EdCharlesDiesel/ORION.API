using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ORION.Admin.Models;

namespace ORION.Admin.Controllers
{

    public class EXCOController : Controller
    {
        private readonly ILogger<EXCOController> _logger;

        public EXCOController(ILogger<EXCOController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
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