using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using weddinPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace weddinPlanner.Controllers
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
            List<Wedding> WeddingList = _context.Weddings.Include(j => j.Guests).OrderByDescending(d => d.CreatedAt).ToList();
            if (HttpContext.Session.GetString("UserEmail") == null)
            {
                //The user is not logged in and we need to kick them out
                return RedirectToAction("Index");
            }
            ViewBag.LoggedInUser = _context.Users.FirstOrDefault(d => d.Email == HttpContext.Session.GetString("UserEmail"));
            return View("Dashboard", WeddingList);
        }

        [HttpGet("AddWedding")]
        public IActionResult AddWedding()
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
            {
                //The use is not logged in and we need to kick them out
                return RedirectToAction("Index");
            }
            ViewBag.LoggedInUser = _context.Users.FirstOrDefault(d => d.Email == HttpContext.Session.GetString("UserEmail"));
            return View();
        }

        [HttpPost("AddWeddingToDB")]
        public IActionResult AddWeddingToDB(Wedding newWedding)
        {
            if (ModelState.IsValid)
            {
                _context.Weddings.Add(newWedding);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.LoggedInUser = _context.Users.FirstOrDefault(d => d.Email == HttpContext.Session.GetString("UserEmail"));
                return View("AddWedding");
            }
        }

        [HttpGet("Wedding/{wid}")]
        public IActionResult OneWedding(int wid)
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
            {
                //The use is not logged in and we need to kick them out
                return RedirectToAction("Index");
            }
            ViewBag.LoggedInUser = _context.Users.FirstOrDefault(d => d.Email == HttpContext.Session.GetString("UserEmail"));
            ViewBag.Wedding = _context.Weddings.Include(s => s.Guests).ThenInclude(p => p.User).FirstOrDefault(f => f.WeddingId == wid);
            return View();
        }

        [HttpGet("Wedding/Delete/{wid}")]
        public IActionResult DeleteWedding(int wid)
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
            {
                //The use is not logged in and we need to kick them out
                return RedirectToAction("Index");
            }
            Wedding WeddingToDelete = _context.Weddings.SingleOrDefault(f => f.WeddingId == wid);
            _context.Weddings.Remove(WeddingToDelete);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpPost("RSVP")]
        public IActionResult RSVP(RSVP newRSVP)
        {
            _context.RSVPs.Add(newRSVP);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpPost("UnRSVP")]
        public IActionResult UnRSVP(RSVP removeRSVP)
        {
            var userRSVP = _context.RSVPs.FirstOrDefault(r => r.UserId == removeRSVP.UserId && r.WeddingId == removeRSVP.WeddingId);
            _context.RSVPs.Remove(userRSVP);
            _context.SaveChanges();
            return Redirect("Dashboard");
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
