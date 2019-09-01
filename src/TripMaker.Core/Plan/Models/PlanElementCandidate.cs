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
                                    IList<string> types,  double? rating, int? price, double? popularity)
        {
            PlaceName = placeName;
            PlaceId = placeId;
            Location = location;
            FormattedAddress = formattedAddress;
            Rating = (decimal?)rating;
            Price = (decimal?)price;
            Popularity = (decimal?)popularity;
            ElementTypes = new List<PlanElementType>(types.Count);
            foreach (var i in types)
            {
                var type = GooglePlaceTypes.CheckPlanElemntyType(i);
                if(type != PlanElementType.Nothing) ElementTypes.Add(type);
            }
                
            OpeningHours = new List<PlanElementOpeningHours>();
            if(openingHours == null)
            {
                OpeningHours.Add(new PlanElementOpeningHours(0, null, new TimeSpan(0, 0, 0), null));
            } else
            {
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

        public bool IsOpen(DateTime checkDate)
        {
            if (OpeningHours.Any(x => x.DayOpen == 0 && TimeSpan.Compare(x.Open, new TimeSpan(0, 0, 0)) == 0 && !x.Close.HasValue)) //always open
                return true;

            var oh = OpeningHours.FirstOrDefault(x => x.DayOpen == (int)checkDate.DayOfWeek);
            if (oh == null)
                return false;

            if(!oh.Close.HasValue) 
                return (TimeSpan.Compare(oh.Open, checkDate.TimeOfDay) <= 0);
            else
                return (TimeSpan.Compare(oh.Open, checkDate.TimeOfDay) <= 0) && (TimeSpan.Compare(checkDate.TimeOfDay, oh.Close.Value) <= 0 || oh.DayClose != oh.DayOpen);

        }

        public DateTime GetCloseDateTime(DateTime startDate, DateTime dateAfterClose)
        {
            //zakladam ze w ten dzien otwarte bylo bo sprawdzane przed ta funkcja
            var currentDay = OpeningHours.FirstOrDefault(x => x.DayOpen == (int)startDate.DayOfWeek);

            if (currentDay.DayClose == null)
                return new DateTime(startDate.Year, startDate.Month, startDate.Day, 23, 59, 59);
            else
            {
                if(currentDay.DayClose.Value> currentDay.DayOpen)
                    return new DateTime(startDate.Year, startDate.Month, startDate.Day).AddDays(1).Add(currentDay.Close.Value);
                else
                    return new DateTime(startDate.Year, startDate.Month, startDate.Day).Add(currentDay.Close.Value);
            }
        }

    }
}