using Ripple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ripple.Services
{
    public class FilterResultsService
    {
        public IEnumerable<Events> FilterResults (IEnumerable<Events> Events, Search EventFilter)
        {
            if (!String.IsNullOrEmpty(EventFilter.Category))
                Events = Events.Where(a => a.Category.Contains(EventFilter.Category)).Select(a => a);
            if(!String.IsNullOrEmpty(EventFilter.City))
                Events = Events.Where(a => a.City.Contains(EventFilter.City)).Select(a => a);
            if (!String.IsNullOrEmpty(EventFilter.Venue))
                Events = Events.Where(a => a.Venue.Contains(EventFilter.Venue)).Select(a => a);
            
            return Events;
        }
    }
}