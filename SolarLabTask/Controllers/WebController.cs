using Microsoft.AspNetCore.Mvc;
using SolarLabTask.Interfaces.Repos;
using SolarLabTask.Interfaces.Services;

namespace SolarLabTask.Controllers
{
    public class WebController : Controller
    {
        private readonly ILogger<WebController> _logger;
        private readonly IPersonListRepo _list;
        private readonly IPersonListService _service;

        public WebController(ILogger<WebController> logger, IPersonListRepo list, IPersonListService service)
        {
            _logger = logger;
            _list = list;
            _service = service;
        }

        public IActionResult Index()
        {
            int ID = 1; // test Value
            ViewData["List"] = _service.getNearBD(ID, 5);
            return View();
        }

        public IActionResult All()
        {
            int ID = 1; // test Value
            ViewData["List"] = _list.GetListByUserId(ID);
            return View();
        }
    }
}
