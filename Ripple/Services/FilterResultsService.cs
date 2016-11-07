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
                Events = Events.Where(a => a.Category.ToLower().Contains(EventFilter.Category.ToLower())).Select(a => a);
            if(!String.IsNullOrEmpty(EventFilter.City))
                Events = Events.Where(a => a.City.ToLower().Contains(EventFilter.City.ToLower())).Select(a => a);
            if (!String.IsNullOrEmpty(EventFilter.Venue))
                Events = Events.Where(a => a.Venue.ToLower().Contains(EventFilter.Venue.ToLower())).Select(a => a);            
            return Events;
        }
    }
}