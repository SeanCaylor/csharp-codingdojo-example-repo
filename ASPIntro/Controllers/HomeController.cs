using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ASPIntro.Controllers
{
    public class HomeController : Controller // <- inherit from the abstract Controller
    {
        // Attributes are above methods in square brackets.
        [HttpGet("")] // route
        public ViewResult Index()
        {
            return View("Index"); // response to the request
        }

        [HttpGet("/videos")]
        public ViewResult Videos()
        {
            List<string> youtubeVideoIds = new List<string>()
            {
            "5qap5aO4i9A", "EHtsQ9thkIY", "0rBG9BAiiC4", "cCwiZdFz63w", "fb9-OzVuV6g", "-y8aKyi6-OQ", "kVaiWk7H7n0",
            "UDA6Kd6uYqs", "eg9_ymCEAF8", "Q8vnqwtOf8E"
            };

            // This ViewBag only exists for this method and this rendered View.
            ViewBag.YoutubeVideoIds = youtubeVideoIds;
            ViewBag.RandomNumber = new System.Random().Next();

            return View("Videos");
        }

        [HttpGet("{**path}")]
        public RedirectToActionResult Unknown(string path)
        {
            Console.WriteLine($"Unknown route: {path}.");
            return RedirectToAction("Index");
        }


    }
}