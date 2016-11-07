using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ripple.Models
{
    public class Search
    {
        public string Keyword { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
        public DateTime? StartDate { get; set; }
    }
}