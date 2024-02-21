using Microsoft.AspNetCore.Mvc;
using SolarLabTask.Interfaces.Repos;
using SolarLabTask.Interfaces.Services;

namespace SolarLabTask.Controllers
{
    public class PersonListController : Controller
    {
        private readonly ILogger<PersonListController> _logger;
        private readonly IPersonRepo _list;
        private readonly IPersonListService _service;

        public PersonListController(ILogger<PersonListController> logger, IPersonRepo list, IPersonListService service)
        {
            _logger = logger;
            _list = list;
            _service = service;
        }

        public IActionResult Index()
        {
            if (!HttpContext.Session.Keys.Contains("id"))
                return RedirectToAction("Index", "User");

            int ID = (int)HttpContext.Session.GetInt32("id")!;
            ViewData["List"] = _service.getNearBD(ID, 5);
            return View();
        }

        public IActionResult All()
        {
            if (!HttpContext.Session.Keys.Contains("id"))
                return RedirectToAction("Index", "User");

            int ID = (int)HttpContext.Session.GetInt32("id")!;
            ViewData["List"] = _list.GetListByUserId(ID);
            return View();
        }
    }
}
