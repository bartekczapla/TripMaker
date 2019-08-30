using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.ExternalServices.Entities.GooglePlaceDetails
{
    public class OpeningHours
    {
        public bool open_now { get; set; }
        public IList<OpeningHoursPeriods> periods { get; set; }
        public IList<string> weekday_text { get; set; }
    }

    public class OpeningHoursPeriods
    {
        public OpeningHoursPeriodsItem open { get; set; }
        public OpeningHoursPeriodsItem close { get; set; }
    }

    public class OpeningHoursPeriodsItem
    {
        public int day { get; set; }
        public string time { get; set; }
    }
}
