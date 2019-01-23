using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.ExternalServices.Entities.GooglePlaceNearbySearch
{
    public class Photo
    {
        public int height { get; set; }
        public List<object> html_attributions { get; set; }
        public string photo_reference { get; set; }
        public int width { get; set; }
    }
}
