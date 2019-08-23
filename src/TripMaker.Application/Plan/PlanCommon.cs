using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.Plan
{
    public static class PlanCommon
    {
        public static GetPlanInput CreateTestInput()
        {
            return new GetPlanInput
            {
                PlaceName= "Kraków",
                PlaceId= "ChIJ0RhONcBEFkcRv4pHdrW2a7Q",
                StartDate=new DateTime(2019, 9, 1),
                StartTime=new TimeSpan(19, 0, 0),
                EndDate=new DateTime(2019, 9, 4),
                Language= Enums.LanguageType.Pl,
                EndTime=new TimeSpan(18, 0, 0),
                HasJourneyBooked=true,
                HasAccomodationBooked=true,
                PlanAccomodation=new Dto.PlanAccomodationDto("ChIJ8f4YlmxbFkcR5PbsuSmT_tU","Hotel Royal")
            };

        }
    }
}
