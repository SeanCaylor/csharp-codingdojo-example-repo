using System;
using System.Collections.Generic;
using ASPIntro.Models;
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
            // ViewBag.YoutubeVideoIds = youtubeVideoIds;
            // ViewBag.RandomNumber = new System.Random().Next();

            ViewBag.Message = "You can use the ViewBag & a ViewModel together!";

            VideosView viewModel = new VideosView()
            {
                YoutubeVideoIds = youtubeVideoIds,
                RandomNumber = new System.Random().Next()
            };

            return View("Videos", viewModel);
            // return render_template("Videos", view_model={"video_ids": ["one", "two"], "message": "lol"})
        }

        // 1. Get the page with the registration <form>
        [HttpGet("/users/register")]
        public ViewResult Register()
        {
            return View("Register");
        }

        // 2. Handle the POST from the registration <form> submission
        [HttpPost("/users/process-registration")]
        public ViewResult ProcessRegistration(User newUser)
        {
            return View("Guest", newUser);
        }

        [HttpGet("{**path}")]
        public RedirectToActionResult Unknown(string path)
        {
            Console.WriteLine($"Unknown route: {path}.");
            return RedirectToAction("Index");
        }

        // EXTRA EXAMPLE: ViewModel used for both displaying and creating data.
        [HttpGet("/users/register2")]
        public ViewResult Register2()
        {
            RegisterView viewModel = new RegisterView()
            {
                NewUser = new User(),
                Message = "Hello world from the view model."
            };

            return View("Register2", viewModel);
        }

        [HttpPost("/users/process-registration2")]
        public ViewResult ProcessRegistration2(RegisterView viewModel)
        {
            return View("Guest", viewModel.NewUser);
        }
    }
}