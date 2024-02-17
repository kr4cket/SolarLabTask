using Microsoft.AspNetCore.Mvc;

namespace SolarLabTask.Controllers
{
    public class WebController : Controller
    {
        private readonly ILogger<WebController> _logger;

        public WebController(ILogger<WebController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
