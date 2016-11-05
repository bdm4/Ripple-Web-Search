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
       
        public ActionResult View(string Search, DateTime StartDate, string Title, string Time)
        {
            var evnt = EventsDBContext.Events.SingleOrDefault(a => a.StartDate.Value == StartDate && a.Title == Title && a.Time == Time);
            ViewBag.SearchTerm = Search;
            return View(evnt);
        }
    }
}