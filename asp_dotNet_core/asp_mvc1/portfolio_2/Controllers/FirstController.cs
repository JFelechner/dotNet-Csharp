
using Microsoft.AspNetCore.Mvc;

namespace portfolio_1
{
    public class FirstController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View("Index");
        }

        [HttpGet("projects")]
        public ViewResult Second()
        {
            return View("Projects");
        }

        [HttpGet("contact")]
        public ViewResult Third()
        {
            return View("Contact");
        }
    }
}