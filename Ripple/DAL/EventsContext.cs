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
    public class EventsContext : IEventsContext, IDisposable
    {
        private IEnumerable<Events> _Events;

        /// <summary>
        /// The contructor will read in from the flat file and serialize it to a list.
        /// </summary>
        public EventsContext()
        {
            if (_Events == null)
            {
                _Events = new List<Events>();
                JsonSerializer serializer = new JsonSerializer();

                string path = HttpContext.Current.Server.MapPath("~/DAL/Events.json");

                using (StreamReader r = new StreamReader(path))
                {
                    _Events = JsonConvert.DeserializeObject<IEnumerable<Events>>(r.ReadToEnd());
                }
            }
        }

        public IList<Events> Events {
            get { return _Events.ToList(); }  //typically this is a dbset, but since the data source is simple we can do this.          
        }

        public void Dispose()
        {
            /* 
             * Because we are using the OWIN Context to inject our data source we need to
             * implement IDisposable. But since our datasource is an IEnumberable of events
             * There isn't really anything to do here. I guess we could empty the IEnumberable<T>,
             * but since the ctor creats a new list anyways we don't need to do that.
             * */            
        }
    }
}