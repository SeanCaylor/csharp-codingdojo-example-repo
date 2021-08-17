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
    public class TripsController : Controller
    {
        private readonly ILogger<TripsController> _logger;

        private BeltPrepContext db;
        public TripsController(BeltPrepContext context)
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

        [HttpGet("/trips")]
        public IActionResult All()
        {

            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Trip> trips = db.Trips.ToList();
            return View("All", trips);
        }

        [HttpGet("/trips/new")]
        public IActionResult New()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("New");
        }

        [HttpPost("/trips/create")]
        public IActionResult Create(Trip newTrip)
        {

            if (ModelState.IsValid == false)
            {
                // Back to form to display errors.
                return View("New");
            }

            if (newTrip.Date <= DateTime.Now)
            {
                ModelState.AddModelError("Date", "must be in the future.");
                return View("New");
            }

            newTrip.UserId = (int)uid;
            db.Trips.Add(newTrip);
            db.SaveChanges();
            return RedirectToAction("All");
        }
    }
}
