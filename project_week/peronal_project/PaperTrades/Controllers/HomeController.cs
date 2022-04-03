﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaperTrades.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace PaperTrades.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        private readonly ILogger<HomeController> _logger;

        //public object<> GetAllCryptos(){}

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.loggedIn = false;
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.UserName == newUser.UserName))
                {
                    ModelState.AddModelError("UserName", "UserName already in use!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Users.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetString("UserName", newUser.UserName);
                return RedirectToAction("dashboard");
            }
            else
            {
                return View("Index");
            }
        }
        [HttpGet("Logout")]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost("login")]
        public IActionResult Login(LogUser logUser)
        {
            if (ModelState.IsValid)
            {
                User userInDb = _context.Users.FirstOrDefault(s => s.UserName == logUser.LUserName);
                if (userInDb == null)
                {
                    ModelState.AddModelError("LUserName", "Invalid login attempt");
                    return View("Index");
                }
                PasswordHasher<LogUser> Hasher = new PasswordHasher<LogUser>();
                PasswordVerificationResult result = Hasher.VerifyHashedPassword(logUser, userInDb.Password, logUser.LPassword);
                if (result == 0)
                {
                    ModelState.AddModelError("LUserName", "Invalid login attempt");
                    return View("Index");
                }
                HttpContext.Session.SetString("UserName", userInDb.UserName);
                return RedirectToAction("dashboard");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("allcryptos")]
        public IActionResult AllCryptos()
        {
            string APIinfo = String.Format("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false");
            WebRequest requestObj = WebRequest.Create(APIinfo);
            //requestObj.Method = "GET";
            HttpWebResponse responseObj = null;
            responseObj = (HttpWebResponse)requestObj.GetResponse();
            string strResult = null;
            using (Stream stream = responseObj.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                strResult = sr.ReadToEnd();
                sr.Close();
            }
            // Console.WriteLine("API DATA HERE:" + strResult);
            string UserName = HttpContext.Session.GetString("UserName");
            User loggedIn = _context.Users
            .FirstOrDefault(d => d.UserName == UserName);
            
            ViewBag.AllCryptos = JsonConvert.DeserializeObject(strResult);
            if (UserName == null)
            {
                ViewBag.loggedIn = false;
                return View();
            }
            else
            {
                ViewBag.loggedIn = true;
                //ViewBag.loggedIn = loggedIn;
                return View(loggedIn);
            }
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            string UserName = HttpContext.Session.GetString("UserName");
            User loggedIn = _context.Users
            // .Include(s => s.isParticipating)
            .FirstOrDefault(d => d.UserName == UserName);
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View("Index");
            }
            else
            {
                // VOLUME DESC
                string APIinfo = String.Format("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=volume_desc&per_page=100&page=1&sparkline=false");
                WebRequest requestObj = WebRequest.Create(APIinfo);
                //requestObj.Method = "GET";
                HttpWebResponse responseObj = null;
                responseObj = (HttpWebResponse)requestObj.GetResponse();
                string strResult = null;
                using (Stream stream = responseObj.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    strResult = sr.ReadToEnd();
                    sr.Close();
                }
                ViewBag.AllCryptos = JsonConvert
                .DeserializeObject(strResult);

                // Change Percentage
                string APIinfo2 = String.Format("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=price_change_percentage_24h_desc&per_page=10&page=1&sparkline=false");
                WebRequest requestObj2 = WebRequest.Create(APIinfo2);
                //requestObj.Method = "GET";
                HttpWebResponse responseObj2 = null;
                responseObj2 = (HttpWebResponse)requestObj2.GetResponse();
                string strResult2 = null;
                using (Stream stream2 = responseObj2.GetResponseStream())
                {
                    StreamReader sr2 = new StreamReader(stream2);
                    strResult2 = sr2.ReadToEnd();
                    sr2.Close();
                }
                ViewBag.AllCryptos2 = JsonConvert
                .DeserializeObject(strResult2);

                // PRICE
                string APIinfo3 = String.Format("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false");
                WebRequest requestObj3 = WebRequest.Create(APIinfo3);
                //requestObj.Method = "GET";
                HttpWebResponse responseObj3 = null;
                responseObj3 = (HttpWebResponse)requestObj3.GetResponse();
                string strResult3 = null;
                using (Stream stream3 = responseObj3.GetResponseStream())
                {
                    StreamReader sr3 = new StreamReader(stream3);
                    strResult3 = sr3.ReadToEnd();
                    sr3.Close();
                }
                // Console.WriteLine("API DATA HERE:" + strResult);
                ViewBag.AllCryptos3 = JsonConvert
                .DeserializeObject(strResult3);

                ViewBag.Wallets = _context.Users
                .Include(s => s.myWallets)
                .FirstOrDefault(s => s.UserName == UserName);
                return View(loggedIn);
            }
        }


        [HttpGet("/crypto/{cid}")]
        public IActionResult ViewOneCrypto(string cid)
        {
            string UserName = HttpContext.Session.GetString("UserName");
            if (UserName == null)
            {
                return View("Index");
            }
            else
            {
                string APIinfo = String.Format("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false");
                WebRequest requestObj = WebRequest.Create(APIinfo);
                //requestObj.Method = "GET";
                HttpWebResponse responseObj = null;
                responseObj = (HttpWebResponse)requestObj.GetResponse();
                string strResult = null;
                using (Stream stream = responseObj.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    strResult = sr.ReadToEnd();
                    sr.Close();
                }
                ViewBag.AllCryptos = JsonConvert
                .DeserializeObject(strResult); //All cryptos
                Wallet wallet = _context.Wallets
                .Include(s => s.Owner)
                .FirstOrDefault(s => s.IsTracking == cid);
                return View(wallet);
            }
        }

        [HttpPost("new")]
        public IActionResult AddWallet(Wallet newWall)
        {
            string UserName = HttpContext.Session.GetString("UserName");
            User loggedIn = _context.Users
            .FirstOrDefault(d => d.UserName == UserName);
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {
                //     ViewBag.OneUser = _context.Users
                // .FirstOrDefault(d => d.UserName == UserName);
                _context.Wallets.Add(newWall);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }
        [HttpPost("/buy/{cid}")]
        public IActionResult BuyCrypto(Receipt newRec, string cid){
            string UserName = HttpContext.Session.GetString("UserName");
            User loggedIn = _context.Users
            .FirstOrDefault(d => d.UserName == UserName);

            _context.Receipts.Add(newRec);
            _context.SaveChanges();

            Wallet original = _context.Wallets
            .FirstOrDefault(s => s.IsTracking == cid);

            Receipt currentRec = _context.Receipts
            .OrderByDescending( s => s.CreatedAt)
            .FirstOrDefault(s => s.UserId == loggedIn.UserId && s.WalletId == original.WalletId);
            currentRec.Value = newRec.Quantity * newRec.TransactionPrice;
            _context.SaveChanges();

            original.CurrPrice = newRec.TransactionPrice;
            original.Quantity += newRec.Quantity;
            original.UpdatedAt = newRec.UpdatedAt;
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpPost("/sell/{cid}")]
        public IActionResult SellCrypto(Receipt newRec, string cid){
            Wallet original = _context.Wallets
            .FirstOrDefault(s => s.IsTracking == cid.ToString());
            if(newRec.TransactionPrice > original.BuyInPrice)
                {
                    newRec.Gain = (newRec.Quantity * newRec.TransactionPrice) - (newRec.Quantity * original.BuyInPrice);
                } else {
                    newRec.Loss = (newRec.Quantity * original.BuyInPrice) - (newRec.Quantity * newRec.TransactionPrice);
                }
            _context.Receipts.Add(newRec);
            _context.SaveChanges();
            
            original.CurrPrice = newRec.TransactionPrice;
            original.Quantity -= newRec.Quantity;
            original.UpdatedAt = newRec.UpdatedAt;
            if (newRec.Gain > 0)
            {
                original.Profit += newRec.Gain;
            } else {
                original.Profit -= newRec.Loss;
            }
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
