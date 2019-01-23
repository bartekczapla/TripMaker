using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.ExternalServices.Entities.GooglePlaceSearch
{
    public class Candidate
    {
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public OpeningHours opening_hours { get; set; }
        public List<Photo> photos { get; set; }
        public string place_id { get; set; }
        public PlusCode plus_code { get; set; }
        public double rating { get; set; }
        public List<string> types { get; set; }
    }
}
