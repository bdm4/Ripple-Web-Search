using Ripple.DAL;
using Ripple.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Owin;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using Ripple.Models;

namespace Ripple.Controllers
{
    public class DetailsController : Controller
    {
        #region ctor
        private EventsContext db;
        public DetailsController() { }
        public DetailsController(EventsContext context)
        {
            db = context;
        }
        public EventsContext EventsDBContext
        {
            get { return db ?? System.Web.HttpContext.Current.GetOwinContext().Get<EventsContext>(); }
            private set { db = value; }
        }
        #endregion

        /// <summary>
        /// Returns a detailed view of an event while preserving search state.
        /// </summary>
        /// <param name="SearchTerm">Search term that was entered in the search form</param>
        /// <param name="Category">Catergory for the Advanced filter</param>
        /// <param name="StartDateFilter">Start date for the Advanced filter</param>
        /// <param name="City">City for the Advanced filter</param>
        /// <param name="Venue">Venue for the filter</param>
        /// <param name="StartDate">StartDate is part of the compound key to uniquely identify an event</param>
        /// <param name="Title">Title is part of the compound key to uniquely identify an event</param>
        /// <param name="Time">Time is part of the compound key to uniquely identify an event</param>
        /// <returns></returns>
        public ActionResult View(string SearchTerm, string Category, DateTime? StartDateFilter, string City, string Venue, DateTime StartDate, string Title, string Time)
        {
            var evnt = EventsDBContext.Events.SingleOrDefault(a => a.StartDate.Value == StartDate && a.Title == Title && a.Time == Time); //Return a single event or nulll
            ViewBag.SearchTerm = SearchTerm; //pass the search term back to the details form
            ViewBag.Category = Category;
            ViewBag.StartDate = StartDateFilter;
            ViewBag.City = City;
            ViewBag.Venue = Venue;

            return View(evnt);
        }
    }
}