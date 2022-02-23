using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using productsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace productsAndCategories.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.AllCategories = _context.Categories.Include(a => a.ProductsList).OrderBy(a => a.Name).ToList();
            return View();
        }

        [HttpPost("addCategory")]
        public IActionResult addCategory(Category newCategory)
        {
            if(ModelState.IsValid)
            {
                _context.Categories.Add(newCategory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else {
                return View("Index");
            }
        }

        [HttpGet("category/{cid}")]
        public IActionResult OneCategory(int cid)
        {
            Category OneCategory = _context.Categories.Include(s => s.ProductsList).ThenInclude(d => d.Product).FirstOrDefault(a => a.CategoryId == cid);
            ViewBag.AllProducts = _context.Products.OrderBy(a => a.Name).ToList();
            return View(OneCategory);
        }

        [HttpPost("addToCategory")]
        public IActionResult addToCategory(ProductAndCategory newAddition)
        {
            _context.ProductAndCategories.Add(newAddition);
            _context.SaveChanges();
            return Redirect($"/category/{newAddition.CategoryId}");
        }




        [HttpGet("Product")]
        public IActionResult Product()
        {
            ViewBag.AllProducts = _context.Products.OrderBy(a => a.Name).ToList();
            return View();
        }

        [HttpPost("addProduct")]
        public IActionResult addProduct(Product newProduct)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Add(newProduct);
                _context.SaveChanges();
                return RedirectToAction("Product");
            } else {
                return View("Product");
            }
        }

        [HttpGet("product/{cid}")]
        public IActionResult OneProduct(int cid)
        {
            Product OneProduct = _context.Products.Include(s => s.CategoriesList).ThenInclude(d => d.Category).FirstOrDefault(a => a.ProductId == cid);
            ViewBag.AllCategories = _context.Categories.OrderBy(a => a.Name).ToList();
            return View(OneProduct);
        }

        [HttpPost("addToProduct")]
        public IActionResult addToProduct(ProductAndCategory newAddition)
        {
            _context.ProductAndCategories.Add(newAddition);
            _context.SaveChanges();
            return Redirect($"/product/{newAddition.ProductId}");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
