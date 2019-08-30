﻿using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.ExternalServices.Entities.GooglePlaceSearch;

namespace TripMaker.ExternalServices.Entities.GooglePlaceDetails
{
    public class GooglePlaceDetailsResult
    {
        public List<AddressComponent> address_components { get; set; }
        public string adr_address { get; set; }
        public string formatted_address { get; set; }
        public string formatted_phone_number { get; set; }
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string international_phone_number { get; set; }
        public string name { get; set; }
        public List<Photo> photos { get; set; }
        public string place_id { get; set; }
        public double? rating { get; set; }
        public double? price_level { get; set; }
        public string reference { get; set; }
        public List<Review> reviews { get; set; }
        public string scope { get; set; }
        public bool permanently_closed { get; set; }
        public List<string> types { get; set; }
        public double? user_ratings_total { get; set; }
        public string url { get; set; }
        public int utc_offset { get; set; }
        public string vicinity { get; set; }
        public string website { get; set; }
        public OpeningHours opening_hours { get; set; }
    }
}
