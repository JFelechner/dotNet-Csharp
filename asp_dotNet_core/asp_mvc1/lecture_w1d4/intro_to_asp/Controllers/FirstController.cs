
using Microsoft.AspNetCore.Mvc;

namespace intro_to_asp.Controllers
{
    public class FirstController : Controller
    {
        // We run logic in a controller
        // This is where we control our routes and what happens at those routes
        // First, establish the type of route - GET / POST
        [HttpGet]
        // Second, we establish the name of the route
        [Route("")]// An empty string takes me to the empty route
        public ViewResult Index()
        {
            ViewBag.heffamoose = "This is the viewbag";
            return View("Index");
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
                return View("third");
            }
            else
            {
                ViewBag.heffamoose = "This is the viewbag from the third page";
                return View("Index");
            }
        }
    }
}