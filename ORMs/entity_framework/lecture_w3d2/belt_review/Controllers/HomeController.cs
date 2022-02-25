using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using belt_review.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace belt_review.Controllers
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

        [HttpGet("")]
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            ViewBag.Loggedin = false; //IF STATEMENT ADDED TO LAYOUT CSHTML
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                // Make sure the email is unique
                if (_context.Users.Any(e => e.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email is already in use!");
                    return View("Index");
                }
                // Make sure the password is hashed before it goes into the database
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                // Add to db
                _context.Users.Add(newUser);
                // Save changes
                _context.SaveChanges();
                HttpContext.Session.SetString("UserEmail", newUser.Email);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Loggedin = false; //IF STATEMENT ADDED TO LAYOUT CSHTML
                return View("Index");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LogUser loginUser)
        {
            if (ModelState.IsValid)
            {
                // Find the user trying to log in
                User UserInDb = _context.Users.FirstOrDefault(s => s.Email == loginUser.LogEmail);
                if (UserInDb == null)
                {
                    ModelState.AddModelError("LogEmail", "Invalid login attempt");
                    return View("Index");
                }
                // Check if the password is right
                PasswordHasher<LogUser> Haser = new PasswordHasher<LogUser>();
                PasswordVerificationResult result = Haser.VerifyHashedPassword(loginUser, UserInDb.Password, loginUser.LogPassword);
                if (result == 0)
                {
                    // Not the right password
                    ModelState.AddModelError("LogEmail", "Invalid login attempt");
                    return View("Index");
                }
                HttpContext.Session.SetString("UserEmail", UserInDb.Email);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Loggedin = false; //IF STATEMENT ADDED TO LAYOUT CSHTML
                return View("Index");
            }
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
            {
                //The user is not logged in and we need to kick them out
                return RedirectToAction("Index");
            }
            ViewBag.LoggedInUser = _context.Users.Include(d => d.Inventory).Include(f => f.MyOrders).ThenInclude(g => g.Product).FirstOrDefault(d => d.Email == HttpContext.Session.GetString("UserEmail"));
            return View();
        }

        [HttpGet("AddProduct")]
        public IActionResult AddProduct()
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
            {
                //The use is not logged in and we need to kick them out
                return RedirectToAction("Index");
            }
            ViewBag.LoggedInUser = _context.Users.FirstOrDefault(d => d.Email == HttpContext.Session.GetString("UserEmail"));
            return View();
        }

        [HttpPost("AddProductToDB")]
        public IActionResult AddProductToDB(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(newProduct);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.LoggedInUser = _context.Users.FirstOrDefault(d => d.Email == HttpContext.Session.GetString("UserEmail"));
                return View("AddProduct");
            }
        }

        [HttpGet("AllProducts")]
        public IActionResult AllProducts()
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
            {
                //The use is not logged in and we need to kick them out
                return RedirectToAction("Index");
            }
            ViewBag.AllProducts = _context.Products.ToList();
            ViewBag.LoggedInUser = _context.Users.FirstOrDefault(d => d.Email == HttpContext.Session.GetString("UserEmail"));
            return View();
        }

        [HttpGet("Product/{pid}")]
        public IActionResult OneProduct(int pid)
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
            {
                //The use is not logged in and we need to kick them out
                return RedirectToAction("Index");
            }
            ViewBag.LoggedInUser = _context.Users.FirstOrDefault(d => d.Email == HttpContext.Session.GetString("UserEmail"));
            ViewBag.Product = _context.Products.FirstOrDefault(f => f.ProductId == pid);
            return View();
        }

        [HttpGet("Product/Edit/{pid}")]
        public IActionResult EditProduct(int pid)
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
            {
                //The use is not logged in and we need to kick them out
                return RedirectToAction("Index");
            }
            ViewBag.LoggedInUser = _context.Users.FirstOrDefault(d => d.Email == HttpContext.Session.GetString("UserEmail"));
            Product oldProduct = _context.Products.FirstOrDefault(d => d.ProductId == pid);
            return View(oldProduct);
        }

        [HttpPost("Product/Update/{pid}")]
        public IActionResult UpdateProduct(int pid, Product UpdatedProduct)
        {
            Product oldProduct = _context.Products.FirstOrDefault(d => d.ProductId == pid);
            if (ModelState.IsValid)
            {
                oldProduct.ProductName = UpdatedProduct.ProductName;
                oldProduct.Picture = UpdatedProduct.Picture;
                oldProduct.Quantity = UpdatedProduct.Quantity;
                oldProduct.Price = UpdatedProduct.Price;
                oldProduct.UpdateddAt = DateTime.Now;
                _context.SaveChanges();
                return RedirectToAction($"/Product/{pid}");
            }
            else
            {
                ViewBag.LoggedInUser = _context.Users.FirstOrDefault(d => d.Email == HttpContext.Session.GetString("UserEmail"));
                return View("EditProduct", oldProduct);
            }
        }

        [HttpGet("Product/Delete/{pid}")]
        public IActionResult DeleteProduct(int pid)
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
            {
                //The use is not logged in and we need to kick them out
                return RedirectToAction("Index");
            }
            Product ProductToDelete = _context.Products.SingleOrDefault(f => f.ProductId == pid);
            _context.Products.Remove(ProductToDelete);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost("Product/Buy")]
        public IActionResult BuyProduct(Order newOrder)
        {
            Product ProductToBuy = _context.Products.FirstOrDefault(d => d.ProductId == newOrder.ProductId);
            if (ModelState.IsValid)
            {
                _context.Orders.Add(newOrder);
                ProductToBuy.Quantity -= newOrder.Quantity;
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.LoggedInUser = _context.Users.FirstOrDefault(d => d.Email == HttpContext.Session.GetString("UserEmail"));
                ViewBag.Product = _context.Products.FirstOrDefault(f => f.ProductId == newOrder.ProductId);
                ViewBag.ErrorMessage = "Invalid purchase attempt";
                return View("OneProduct", newOrder.ProductId);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
