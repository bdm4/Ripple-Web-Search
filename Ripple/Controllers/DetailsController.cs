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
       
        public ActionResult View(int id)
        {            
            var evnt = EventsDBContext.Events.ElementAt(id);
            return View(evnt);
        }


    }
}