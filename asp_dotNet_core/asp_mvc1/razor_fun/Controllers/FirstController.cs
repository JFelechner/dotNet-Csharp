
using Microsoft.AspNetCore.Mvc;

namespace razor_fun.Controllers
{
    public class FirstController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View("Index");
        }
    }
}