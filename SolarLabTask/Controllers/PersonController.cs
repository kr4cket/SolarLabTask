using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SolarLabTask.Interfaces.Repos;
using SolarLabTask.Interfaces.Services;
using SolarLabTask.Models;
using System;

namespace SolarLabTask.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<PersonListController> _logger;
        private readonly IPersonService _service;
        private readonly IPersonRepo _person;

        public PersonController(ILogger<PersonListController> logger, IPersonRepo person, IPersonService service)
        {
            _logger = logger;
            _service = service;
            _person = person;
        }
        public IActionResult Index(int Id)
        {
            if (!HttpContext.Session.Keys.Contains("id"))
                return RedirectToAction("Index", "User");

            ViewData["Person"] = _person.Get(Id);
            ViewData["List"] = new SelectList(_service.GetCategoryList(), "Id", "Name", _person.Get(Id).PersonCategory.Id);
            return View();
        }
        public IActionResult Update(Person person)
        {
            IFormFile? file = null;

            if (HttpContext.Request.Form.Files.Count > 0)
                file = HttpContext.Request.Form.Files.First();

            int ID = (int)HttpContext.Session.GetInt32("id")!;
            _service.UpdateUser(person, ID, file);
            return RedirectToAction("Index", new { id = person.Id});
        }

        public IActionResult Delete(Person person)
        {
            _person.Delete(person);
            return RedirectToAction("Index", "PersonList");
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (!HttpContext.Session.Keys.Contains("id"))
                return RedirectToAction("Index", "User");

            ViewData["List"] = new SelectList(_service.GetCategoryList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Add(Person person)
        {
            IFormFile? file = null;

            if (HttpContext.Request.Form.Files.Count > 0)
                file = HttpContext.Request.Form.Files.First();

            int ID = (int)HttpContext.Session.GetInt32("id")!;
            _service.CreateUser(person, ID, file);
            return RedirectToAction("Index", "PersonList");
        }
    }
}
