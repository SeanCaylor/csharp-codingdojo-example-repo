using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BeltPrep.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BeltPrep.Controllers
{
    public class DestinationMedias : Controller
    {
        private readonly ILogger<DestinationMedias> _logger;

        private BeltPrepContext db;
        public DestinationMedias(BeltPrepContext context)
        {
            db = context;
        }

        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }

        private bool isLoggedIn
        {
            get
            {
                return uid != null;
            }
        }

        [HttpGet("/location-media/new")]
        public IActionResult New()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("New");
        }

        [HttpPost("/location-media/create")]
        public IActionResult Create(DestinationMedia newDestinationMedia)
        {

            if (ModelState.IsValid == false)
            {
                // Back to form to display errors.
                return View("New");
            }

            newDestinationMedia.UserId = (int)uid;
            db.DestinationMedias.Add(newDestinationMedia);
            db.SaveChanges();
            return RedirectToAction("Details", new { destinationMediaId = newDestinationMedia.DestinationMediaId });
        }

        [HttpGet("/location-media/{destinationMediaId}")]
        public IActionResult Details(int destinationMediaId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            DestinationMedia destMedia = db.DestinationMedias.FirstOrDefault(dm => dm.DestinationMediaId == destinationMediaId);

            if (destMedia == null)
            {
                return RedirectToAction("New");
            }

            return View("Details", destMedia);
        }
    }
}
