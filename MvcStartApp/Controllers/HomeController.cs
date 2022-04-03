using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcStartApp.Models;
using MvcStartApp.Models.Db;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IBlogRepository _repo;
        //private readonly ILogsRepository _repo;
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger, ILogsRepository repo)
        public HomeController(ILogger<HomeController> logger, ILogsRepository repo)

        {
            //_repo = repo;
            _logger = logger;
        }

        // Сделаем метод асинхронным
        public async Task<IActionResult> Index()
        {
            //// Добавим создание нового пользователя
            //var newUser = new User()
            //{
            //    Id = Guid.NewGuid(),
            //    FirstName = "Andrey",
            //    LastName = "Petrov",
            //    JoinDate = DateTime.Now
            //};

            //// Добавим в базу
            //await _repo.AddUser(newUser);

            //// Выведем результат
            //Console.WriteLine($"User with id {newUser.Id}, named {newUser.FirstName} was successfully added on {newUser.JoinDate}");

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
