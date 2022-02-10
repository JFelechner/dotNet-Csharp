
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace intro_to_asp.Controllers
{
    public class FirstController : Controller
    {
        public static List<string> NameSuggestions = new List<string>();
        // We run logic in a controller
        // This is where we control our routes and what happens at those routes
        // First, establish the type of route - GET / POST
        [HttpGet]
        // Second, we establish the name of the route
        [Route("")]// An empty string takes me to the empty route
        public ViewResult Index()
        {
            ViewBag.heffamoose = "This is the viewbag";
            ViewBag.suggestions = NameSuggestions;
            return View("Index");
        }

        [HttpPost("firstPost")]
        public IActionResult Firstpost(string names)
        {
            NameSuggestions.Add(names);
            return RedirectToAction("Index");
        }
        
        [HttpGet("second")] // This is the short hand way of writing the route
        public RedirectToActionResult Second()
        {
            return RedirectToAction("Index");
        }

        [HttpGet("third/{param}")]
        // IActionResult allows us to return anything (such as View or RedirectToAction)
        public IActionResult Third(string whateverIWant)
        {
            if (whateverIWant == "apple")
            {
                return View("Third");
            }
            else
            {
                ViewBag.heffamoose = "This is the viewbag from the third page";
                return View("Index");
            }
        }
    }
}