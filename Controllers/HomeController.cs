using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // for session use 

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            // Generate new random passcode
            // Assign local variable for new passcode
            // if current count is null, set count to 1
                // int? count = 1;
            // else increment+1
                // int? count++;

            //add the information into the viewbag

            return View();
        }
    }
}