using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ripple.Models
{
    /// <summary>
    /// Events model gets it's data from Events.Json which is a local file
    /// </summary>
    public class Events
    {
        /* Sample from events.json
         *  "Region": "Central",
        "Category": "Fairs/Festivals",
        "StartDate": "1/4/2018",
        "EndDate": "1/5/2018",
        "Title": "Worthington Historical Society Antiques Show",
        "Description": "High-quality wares will be offered for sale from across the Midwest and Northeast. Exhibitors to bring city, country and painted furniture as well as items randing from stoneware to decoys to antique dolls to estate and costume jewelry.  No reproductions ",
        "Venue": "Holiday Inn Hotel, Worthington",
        "Address": "7007 N. High St.",
        "City": "Worthingotn",
        "Phone": "614/885-1247",
        "Website": "worthingtonhistory.org",
        "Time": "Sat. 10 a.m.–5 p.m.; Sun. 11 a.m.–4 p.m.",
        "Price": "$8"
        */

        public string Region { get; set; }
        public string Category { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Venue { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Time { get; set; }
        public string Price { get; set; }
    }
}