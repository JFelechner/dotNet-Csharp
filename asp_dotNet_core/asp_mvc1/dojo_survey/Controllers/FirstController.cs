
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace dojo_survey
{
    public class FirstController : Controller
    {

        [HttpGet("")]
        public ViewResult Index()
        {
            
            return View("Index");
        }

        [HttpPost("firstPost")] // Post location of form on index page
        public IActionResult Firstpost(string name, string dojoLocation, string favoriteLanguage, string comment)
        {
            ViewBag.newName = name;
            ViewBag.dojo = dojoLocation;
            ViewBag.language = favoriteLanguage;
            ViewBag.newComment = comment;
            return View("Result");
        }

        [HttpGet("result")]
        public ViewResult Second()
        {
            return View("Result");
        }
    }

}