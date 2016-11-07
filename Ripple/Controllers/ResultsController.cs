using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ripple.Models;
using Ripple.DAL;
using Ripple.DAL.Interfaces;
using Microsoft.AspNet.Identity.Owin;
using Ripple.Services;

namespace Ripple.Controllers
{
    public class ResultsController : Controller
    {
        #region ctor
        private EventsContext db;
        public ResultsController() { }       
        public ResultsController(EventsContext context)
        {            
            db = context;
        }
        public EventsContext EventsDBContext
        {   
            get { return db ?? System.Web.HttpContext.Current.GetOwinContext().Get<EventsContext>(); }
            private set { db = value; }
        }
        #endregion

        // GET: Results
        public ActionResult Index()
        {           
            ViewBag.SearchTerm = null;
            return View();
        }

        [HttpPost]
        public ActionResult Index(Search Searchmodel)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(Searchmodel.Keyword))
                {
                    return View(); //If search is empty return no results.
                }
                var lowercasekey = Searchmodel.Keyword.ToLower(); //change our keyword search to lower case

                //Get a keyword search base, this is a greedy search
                var searchresults = EventsDBContext.Events.Where(a => a.Description.ToLower().Contains(lowercasekey) ||
                                       a.Category.ToLower().Contains(lowercasekey) ||
                                       a.City.ToLower().Contains(lowercasekey) ||
                                       a.Venue.ToLower().Contains(lowercasekey))
                                       .Select(a => a);

                //If the keyword looks like a date we'll query that.
                if (Searchmodel.StartDate.HasValue)
                {
                    searchresults = searchresults.Where(d => d.StartDate >= Searchmodel.StartDate);
                }
                //The search design was to be greedy with filtering available to the user. So all initial searched are by keywords in the filterable inputs.
                var service = new FilterResultsService(); //This service is designed to filter results of a keywords query.
                searchresults = service.FilterResults(searchresults, Searchmodel);

                //Use ViewData to persist Search state            
                ViewBag.Category = Searchmodel.Category;
                ViewBag.StartDate = Searchmodel.StartDate;
                ViewBag.City = Searchmodel.City;
                ViewBag.Venue = Searchmodel.Venue;
                //We pass this back to show in the partial form view and filter form inputs.
                ViewBag.SearchTerm = Searchmodel.Keyword;
                return View(searchresults);
            }
            return View();
        }
    }
}