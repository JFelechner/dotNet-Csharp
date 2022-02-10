
using Microsoft.AspNetCore.Mvc;

namespace portfolio_1
{
    public class FirstController : Controller
    {
        [HttpGet("")]
        public string Index()
        {
            return "This is my Index!";
        }

        [HttpGet("projects")]
        public string Second()
        {
            return "These are my projects";
        }

        [HttpGet("contact")]
        public string Third()
        {
            return "This is my Contact!";
        }
    }
}