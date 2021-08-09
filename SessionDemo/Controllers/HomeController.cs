using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SessionDemo.Models;

namespace SessionDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/login")]
        public IActionResult Login(User newUser)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("Username", newUser.Username);
                return RedirectToAction("StoryTime");
            }

            // If ModelState is invalid, send them back to form to see errors.
            return View("Index");
        }

        [HttpGet("/story")]
        public ViewResult StoryTime()
        {
            string story = HttpContext.Session.GetString("story");

            if (story == null)
            {
                // No story added yet, set it to an empty string so it's ready to 
                // be concatenated to.
                HttpContext.Session.SetString("story", "");
            }

            return View("StoryTime");
        }

        [HttpPost("/story/add")]
        public RedirectToActionResult AddToStory(StoryFragment storyFragment)
        {
            string updatedStory = HttpContext.Session.GetString("story");
            updatedStory += " " + storyFragment.Word;
            HttpContext.Session.SetString("story", updatedStory);
            return RedirectToAction("StoryTime");
        }

        [HttpPost("/logout")]
        public RedirectToActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
