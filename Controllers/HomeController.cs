using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // for session use 
using RandomPasscode.Models;
namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            if(!HttpContext.Session.GetInt32("count").HasValue)
            {
                int? currCount = HttpContext.Session.GetInt32("count");
                HttpContext.Session.SetInt32("count", 0);
            }



            return View();
        }

        [HttpPost("newcode")]
        public IActionResult NewCode()
        {
            Random r = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            // Generate new random passcode
            string newPassCode = new string(Enumerable.Repeat(chars, 14)
                .Select(str => str[r.Next(str.Length)]).ToArray());

            // Increment the count in session
            int currCount = (int) HttpContext.Session.GetInt32("count");
            if(currCount != null)
            currCount++;
            HttpContext.Session.SetInt32("count", currCount);


            // Add the information into the viewbag
            ViewBag.PassCode = newPassCode;
            ViewBag.Count = currCount;

            return View("Index");
        }
    }
}