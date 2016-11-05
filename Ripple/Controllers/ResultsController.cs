using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ripple.Models;
using Ripple.DAL;
using Ripple.DAL.Interfaces;
using Microsoft.AspNet.Identity.Owin;

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
        public ActionResult Index(string search)
        {   
            
            var searchresults = EventsDBContext.Events.Where(a => a.Description.Contains(search) || 
                                    a.Category.Contains(search) || 
                                    a.City.Contains(search) || 
                                    a.Venue.Contains(search))                                    
                                .Select(a => a);
            
            ViewBag.SearchTerm = search;
            return View(searchresults);
        }
    }
}