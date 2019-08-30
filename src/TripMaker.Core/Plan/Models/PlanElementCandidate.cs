using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.ExternalServices.Entities.GooglePlaceDetails;

namespace TripMaker.Plan.Models
{
    public class PlanElementCandidate
    {
        public string PlaceName { get; set; }

        public string PlaceId { get; set; }

        public string FormattedAddress { get; set; }

        public Location Location { get; set; }

        public IList<PlanElementType> ElementTypes { get; set; }

        public decimal? Rating { get; set; }

        public decimal? Price { get; set; }

        public decimal? Popularity { get; set; }

        public IList<PlanElementOpeningHours> OpeningHours { get; set; }

        // public IList<PlanElementReview> Reviews { get; set; }

        public PlanElementCandidate(string placeName, string placeId, string formattedAddress, Location location, OpeningHours openingHours,
                                    IList<string> types,  double? rating=null, double? price=null, double? popularity=null)
        {
            PlaceName = placeName;
            PlaceId = placeId;
            Location = location;
            FormattedAddress = formattedAddress;
            Rating = (decimal?)rating;
            Price = (decimal?)price;
            Popularity = (decimal?)popularity;
            ElementTypes = new List<PlanElementType>(types.Count);
            foreach (var i in types) ElementTypes.Add(GooglePlaceTypes.CheckPlanElemntyType(i));

            OpeningHours = new List<PlanElementOpeningHours>(7);
            foreach(var oh in openingHours.periods)
            {              
                TimeSpan openHour=new TimeSpan(0,0,0);
                TimeSpan.TryParse(oh.open.time.Insert(2, ":"), out openHour);
             
                if (oh.close != null)
                {
                    TimeSpan closeHour;
                    TimeSpan.TryParse(oh.close.time.Insert(2, ":"), out closeHour);
                    OpeningHours.Add(new PlanElementOpeningHours(oh.open.day, oh.close.day, openHour, closeHour ));
                } else
                {
                    OpeningHours.Add(new PlanElementOpeningHours(oh.open.day, null, openHour, null));
                }

               
            }

        }

    }
}