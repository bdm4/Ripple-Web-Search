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
        public ActionResult Index(string Search, Events EventFilter = null)
        {              
            if(String.IsNullOrEmpty(Search)) 
            { 
                return View(); //If search is empty return no results.
            }

            var searchresults = EventsDBContext.Events
                                .Select(a => a);


            //If the keyword looks like a date we'll query that.
            DateTime datesearch;
            if(DateTime.TryParse(Search, out datesearch))
            {
                searchresults = searchresults.Where(d => d.StartDate >= datesearch);
            }      
            else //else if the keyword looks like a string then we'll search everything filterable
            {
                searchresults = searchresults.Where(a => a.Description.Contains(Search) ||
                                   a.Category.Contains(Search) ||
                                   a.City.Contains(Search) ||
                                   a.Venue.Contains(Search));
            }     
            //The search design was to be greedy with filtering available to the user. So all initial searched are by keywords in the filterable inputs.
            var service = new FilterResultsService(); //This service is designed to filter results of a keywords query.
            searchresults = service.FilterResults(searchresults, EventFilter);


            ViewData["Category"] = EventFilter.Category; 
            //We pass this back to show in the partial form view and filter form inputs.
            
            ViewBag.StartDate = EventFilter.StartDate;
            ViewBag.EndDate = EventFilter.EndDate;
            ViewBag.City = EventFilter.City;
            ViewBag.Venue = EventFilter.Venue;
            ViewBag.SearchTerm = Search; 
            return View(searchresults);
        }
    }
}