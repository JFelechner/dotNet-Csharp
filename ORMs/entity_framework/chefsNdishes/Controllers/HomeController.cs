using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using chefsNdishes.Models;

namespace chefsNdishes.Controllers
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
            List<Chef> AllChefs = _context.Chefs.Include(d => d.ChefDishes).OrderByDescending (d => d.CreatedAt).ToList();
            return View("Index", AllChefs);
        }

        [HttpGet("addchef")]
        public IActionResult AddChef()
        {
            return View("AddChef");
        }

        [HttpPost("submitNewChef")]
        public IActionResult submitNewChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                _context.Chefs.Add(newChef);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else {
                return View("addchef");
            }
        }

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            ViewBag.AllChefs = _context.Chefs.OrderByDescending (d => d.CreatedAt).ToList(); // needed for chefs on dish list
            List<Dish> AllDishes = _context.Dishes.OrderByDescending (d => d.CreatedAt).ToList();
            return View("Dishes", AllDishes);
        }

        [HttpGet("adddish")]
        public IActionResult AddDish()
        {
            ViewBag.AllChefs = _context.Chefs.ToList(); // needed for drop down selector of chefs
            return View("AddDish");
        }

        [HttpPost("submitNewDish")]
        public IActionResult submitNewDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                _context.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("Dishes");
            } else {
                ViewBag.AllChefs = _context.Chefs.OrderByDescending (d => d.CreatedAt).ToList(); // needed to reload page with drop down list of chefs again
                return View("adddish");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
