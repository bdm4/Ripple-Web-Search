using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ripple.Models;

namespace Ripple.Controllers
{
    public class ResultsController : Controller
    {
        // GET: Results
        public ActionResult Index()
        {           
            ViewBag.SearchTerm = null;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            


            ViewBag.SearchTerm = search;
            return View();
        }
    }
}