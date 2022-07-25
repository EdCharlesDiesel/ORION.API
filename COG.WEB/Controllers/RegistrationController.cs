using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace COG.WEB.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ILogger<AboutController> _logger;

        public RegistrationController(ILogger<AboutController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
