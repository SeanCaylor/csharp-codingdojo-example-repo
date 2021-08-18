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
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("/trips/{tripId}")]
        public IActionResult Details(int tripId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            Trip trip = db.Trips
                // .Include is always giving you the entity from the table
                // being queried, for you to include a property from that entity.
                .Include(trip => trip.CreatedBy)
                .Include(trip => trip.TripDestinations)
                // .ThenInclude is always giving you the datatype of what was
                // just previously included so you can include a property on
                // the entity that was just included.
                .ThenInclude(tripDest => tripDest.DestinationMedia)
                .FirstOrDefault(trip => trip.TripId == tripId);

            if (trip == null)
            {
                return RedirectToAction("New");
            }

            ViewBag.DestinationsToAdd = db.DestinationMedias.ToList();

            return View("Details", trip);
        }

        [HttpPost("/trips/{tripId}/add-destination")]
        public IActionResult AddDestination(int tripId, TripDestination newTripDest)
        {
            newTripDest.TripId = tripId;
            db.TripDestinations.Add(newTripDest);
            db.SaveChanges();
            // The method needs params:        new { paramName = value, param2 = val2 }
            return RedirectToAction("Details", new { tripId = tripId });
        }

        [HttpPost("/trips/{tripId}/remove-destination/{destinationMediaId}")]
        public IActionResult RemoveDestination(int tripId, int destinationMediaId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            TripDestination tripDest = db.TripDestinations.FirstOrDefault(td => td.TripId == tripId && td.DestinationMediaId == destinationMediaId);

            if (tripDest != null)
            {
                db.TripDestinations.Remove(tripDest);
                db.SaveChanges();
            }

            // The method needs params:        new { paramName = value, param2 = val2 }
            return RedirectToAction("Details", new { tripId = tripId });
        }

        [HttpPost("/trips/{tripId}/delete")]
        public IActionResult Delete(int tripId)
        {

            Trip trip = db.Trips.FirstOrDefault(t => t.TripId == tripId);

            // If trip not found OR user is not the creator, redirect them.
            if (trip == null || trip.UserId != uid)
            {
                return RedirectToAction("Index", "Home");
            }

            db.Trips.Remove(trip);
            db.SaveChanges();
            return RedirectToAction("All");
        }

        [HttpGet("/trips/{tripId}/edit")]
        public IActionResult Edit(int tripId)
        {

            Trip trip = db.Trips.FirstOrDefault(t => t.TripId == tripId);

            // If trip not found OR user is not the creator, redirect them.
            if (trip == null || trip.UserId != uid)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("Edit", trip);
        }

        [HttpPost("/trips/{tripId}/update")]
        public IActionResult Update(int tripId, Trip updatedTrip)
        {
            if (updatedTrip.Date <= DateTime.Now)
            {
                ModelState.AddModelError("Date", "must be in the future.");
            }

            if (ModelState.IsValid == false)
            {
                updatedTrip.TripId = tripId;
                // The Edit view needs a Trip model passed just like the 
                // Edit method does.
                return View("Edit", updatedTrip);
            }

            Trip dbTrip = db.Trips.FirstOrDefault(t => t.TripId == tripId);

            if (dbTrip == null)
            {
                return RedirectToAction("Index", "Home");
            }

            dbTrip.UpdatedAt = DateTime.Now;
            dbTrip.Name = updatedTrip.Name;
            dbTrip.Description = updatedTrip.Description;
            dbTrip.Date = updatedTrip.Date;
            db.Trips.Update(dbTrip);
            db.SaveChanges();

            // The method needs params:        new { paramName = value, param2 = val2 }
            return RedirectToAction("Details", new { tripId = tripId });
        }
    }
}
