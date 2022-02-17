using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using crudelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace crudelicious.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Dish> allDishes = _context.Dish.ToList();
            ViewBag.allDishes = allDishes;
            return View();
        }

        [HttpGet("/new")]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost("process")]
        public IActionResult Process(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                Console.WriteLine("It worked!");
                _context.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else {
                return View("New");
            }
        }

        [HttpGet("/{did}")]
        public IActionResult View(int did)
        {
            Dish dishToView = _context.Dish.FirstOrDefault(a => a.DishId == did);
            return View(dishToView);
        }

        [HttpGet("delete/{did}")]
        public IActionResult deleteOne(int did)
        {
            // Step one: find the thing we're trying to delete
            Dish dishToDelete = _context.Dish.SingleOrDefault(a => a.DishId == did);
            _context.Dish.Remove(dishToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{did}")]
        public IActionResult EditOne(int did)
        {
            Dish dishToEdit = _context.Dish.FirstOrDefault(a => a.DishId == did);
            return View(dishToEdit);
        }

        [HttpPost("update/{did}")]
        public IActionResult updateOne(int did, Dish editedDish)
        {
            Dish orignal = _context.Dish.FirstOrDefault(a => a.DishId == did);
            orignal.NameOfDish = editedDish.NameOfDish;
            orignal.ChefName = editedDish.ChefName;
            orignal.Calories = editedDish.Calories;
            orignal.Tastiness = editedDish.Tastiness;
            orignal.Description = editedDish.Description;
            orignal.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");
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
