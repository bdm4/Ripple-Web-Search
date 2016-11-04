using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ripple.Models;
using Ripple.DAL;
using Ripple.DAL.Interfaces;

namespace Ripple.Controllers
{
    public class ResultsController : Controller
    {
        #region ctor
        private IEventsContext db;

        public ResultsController()
        {
            db = new EventsContext(); //faking DI for simplicty
        }
        public ResultsController(IEventsContext context)
        {
            db = context;
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
            var events = db.GetEvents; //Because of the nature of our datasource we need a getter. 
            var searchresults = events.Where(a => a.Description.Contains(search)).Select(a => a);
            
            ViewBag.SearchTerm = search;
            return View(searchresults);
        }
    }
}