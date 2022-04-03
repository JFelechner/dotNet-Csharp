﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using felechnerCSharpExam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace felechnerCSharpExam.Controllers
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
            ViewBag.Loggedin = false;
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(e => e.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email is already in use!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Users.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetString("UserEmail", newUser.Email);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Loggedin = false;
                return View("Index");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LogUser loginUser)
        {
            if (ModelState.IsValid)
            {
                User UserInDb = _context.Users.FirstOrDefault(s => s.Email == loginUser.LogEmail);
                if (UserInDb == null)
                {
                    ModelState.AddModelError("LogEmail", "Invalid login attempt");
                    return View("Index");
                }
                PasswordHasher<LogUser> Haser = new PasswordHasher<LogUser>();
                PasswordVerificationResult result = Haser.VerifyHashedPassword(loginUser, UserInDb.Password, loginUser.LogPassword);
                if (result == 0)
                {
                    ModelState.AddModelError("LogEmail", "Invalid login attempt");
                    return View("Index");
                }
                HttpContext.Session.SetString("UserEmail", UserInDb.Email);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Loggedin = false; 
                return View("Index");
            }
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            List<ShinDig> ShinDigList = _context.ShinDigs.Include(j => j.Attendees).Include(p => p.Planner).OrderByDescending(d => d.CreatedAt).ToList();
            if (HttpContext.Session.GetString("UserEmail") == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.LoggedInUser = _context.Users.FirstOrDefault(d => d.Email == HttpContext.Session.GetString("UserEmail"));
            return View("Dashboard", ShinDigList);
        }

        [HttpGet("AddShinDig")]
        public IActionResult AddShinDig()
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.LoggedInUser = _context.Users.FirstOrDefault(d => d.Email == HttpContext.Session.GetString("UserEmail"));
            return View();
        }

        [HttpPost("AddShinDigToDB")]
        public IActionResult AddShinDigToDB(ShinDig newShinDig)
        {
            if (ModelState.IsValid)
            {
                _context.ShinDigs.Add(newShinDig);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.LoggedInUser = _context.Users.FirstOrDefault(d => d.Email == HttpContext.Session.GetString("UserEmail"));
                return View("AddShinDig");
            }
        }

        [HttpGet("ShinDig/{sid}")]
        public IActionResult OneShinDig(int sid)
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
            {
                //The use is not logged in and we need to kick them out
                return RedirectToAction("Index");
            }
            ViewBag.LoggedInUser = _context.Users.FirstOrDefault(d => d.Email == HttpContext.Session.GetString("UserEmail"));
            ViewBag.ShinDig = _context.ShinDigs.Include(p => p.Planner).Include(s => s.Attendees).ThenInclude(p => p.User).FirstOrDefault(f => f.ShinDigId == sid);
            return View();
        }

        [HttpGet("ShinDig/Delete/{sid}")]
        public IActionResult DeleteShinDig(int sid)
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
            {
                return RedirectToAction("Index");
            }
            ShinDig ShinDigToDelete = _context.ShinDigs.SingleOrDefault(f => f.ShinDigId == sid);
            _context.ShinDigs.Remove(ShinDigToDelete);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpPost("Join")]
        public IActionResult Join(RSVP newRSVP)
        {
            _context.RSVPs.Add(newRSVP);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpPost("Leave")]
        public IActionResult Leave(RSVP removeRSVP)
        {
            var userRSVP = _context.RSVPs.FirstOrDefault(r => r.UserId == removeRSVP.UserId && r.ShinDigId == removeRSVP.ShinDigId);
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
