using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using view_model_fun.Models;

namespace view_model_fun.Controllers
{
    public class HomeController : Controller
    {
        public List<User> OutputUsers()
        {
            return new List<User>()
            {
                new User(){ FirstName="Moose", LastName="Phillips"},
                new User(){ FirstName="Sarah"},
                new User(){ FirstName="Jerry"},
                new User(){ FirstName="Rene", LastName="Ricky"},
                new User(){ FirstName="Barbarah"}
            };
        }
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            string message = "Hello";
            return View("Index", message);
        }

        [HttpGet("numbers")]
        public IActionResult Second()
        {
            int[] number = new int[]{1,2,3,10,43,5};
            return View("Number", number);
        }

        [HttpGet("users")]
        public IActionResult Third()
        {
            var users = OutputUsers();
            return View("Users", users);
        }

        [HttpGet("user")]
        public IActionResult Fourth()
        {
            // random user
            var random = new Random();
            var users = OutputUsers();
            var user = users[random.Next(users.Count)];
            return View("User", user);
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
