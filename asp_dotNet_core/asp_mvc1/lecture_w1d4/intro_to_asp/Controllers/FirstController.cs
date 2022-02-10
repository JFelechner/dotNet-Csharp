
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
            return View("Index");
        }

        [HttpGet("second")] // This is the short hand way of writing the route
        public string Second()
        {
            return "Hello from the second page!";
        }

        [HttpGet("third/{param}")]
        public string Third(string param)
        {
            return $"The thing you wrote is: {param}";
        }
    }
}