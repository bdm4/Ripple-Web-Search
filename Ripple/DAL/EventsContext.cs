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
    public class EventsContext : IEventsContext
    {
        private IEnumerable<Events> _Events;

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