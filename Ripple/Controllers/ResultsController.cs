using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ripple.Controllers
{
    public class ResultsController : Controller
    {
        // GET: Results
        public ActionResult Index()
        {
            int i = 0;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            int i = 0;
            return View();
        }
    }
}