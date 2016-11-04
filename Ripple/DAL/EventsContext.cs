using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ripple.Models;
using Newtonsoft.Json;
using System.IO;
using Ripple.DAL.Interfaces;

namespace Ripple.DAL
{
    /// <summary>
    /// This is a simple implementation of a data context. We have to get our data in from a flat file that has json data in it. 
    /// We'll read that file in and serialize it to something queryable.
    /// </summary>
    public class EventsContext : IEventsContext
    {
        private IEnumerable<Events> _Events;

        /// <summary>
        /// The contructor will read in from the flat file and serialize it to a list.
        /// </summary>
        public EventsContext()
        {
            _Events = new List<Events>();
            JsonSerializer serializer = new JsonSerializer();

            string path = HttpContext.Current.Server.MapPath("~/DAL/Events.json");

            using (StreamReader r = new StreamReader(path))
            {
                _Events = JsonConvert.DeserializeObject<List<Events>>(r.ReadToEnd());
            }
        }

        public IEnumerable<Events> GetEvents {
            get { return _Events.ToList(); }            
        }
    }
}