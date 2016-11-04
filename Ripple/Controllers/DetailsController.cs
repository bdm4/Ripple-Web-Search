using Ripple.DAL;
using Ripple.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ripple.Controllers
{
    public class DetailsController : Controller
    {
        #region ctor
        private IEventsContext db;

        public DetailsController()
        {
            db = new EventsContext(); //faking DI for simplicty
        }
        public DetailsController(IEventsContext context)
        {
            db = context;
        }
        #endregion
       
        public ActionResult Index(string search)
        {
            var events = db.GetEvents; //Because of the nature of our datasource we need a getter. 
            var searchresults = events.Where(a => a.Description.Contains(search)).Select(a => a);

            ViewBag.SearchTerm = search;
            return View(searchresults);
        }
    }
}