using Microsoft.AspNetCore.Mvc;
using SolarLabTask.Interfaces.Repos;
using SolarLabTask.Interfaces.Services;
using SolarLabTask.Models;
using System;

namespace SolarLabTask.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<PersonListController> _logger;
        private readonly IUserService _service;
        private readonly IUserRepo _user;

        public UserController(ILogger<PersonListController> logger, IUserRepo user, IUserService service)
        {
            _logger = logger;
            _service = service;
            _user = user;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User User)
        {
            if (_service.Auth(HttpContext, User))
            {
                return RedirectToAction("Index", "PersonList");
            } else
            {
                ViewBag.ErrorMsg = "Неправильный логин или пароль!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(User User)
        {
            if (_service.Registration(HttpContext, User))
            {
                return RedirectToAction("Index", "PersonList");
            }
            else
            {
                ViewBag.ErrorMsg = "Пользователь с таким логином уже существует";
                return View();
            }
        }
    }
}
