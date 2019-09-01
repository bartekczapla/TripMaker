using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;
using TripMaker.Enums.PlanFormEnums;

namespace TripMaker.Plan
{
    public static class PlanCommon
    {
        public static CreatePlanInput CreateTestInput()
        {
            var preferedTravelModes = new List<GoogleTravelMode>();
            preferedTravelModes.Add(GoogleTravelMode.Walking);

            var prefered = new List<PlanElementType>();
            prefered.Add(PlanElementType.Culture);
            prefered.Add(PlanElementType.Culture);

            prefered.Add(PlanElementType.Sightseeing);

            var sorted= new List<PlanElementType>();
            sorted.Add(PlanElementType.Culture);
            sorted.Add(PlanElementType.Sightseeing);
            sorted.Add(PlanElementType.Activity);
            sorted.Add(PlanElementType.Entertainment);
            sorted.Add(PlanElementType.Relax);
            sorted.Add(PlanElementType.Partying);
            sorted.Add(PlanElementType.Shopping);

            return new CreatePlanInput
            {
                PlaceName= "Paryż",
                PlaceId= "ChIJD7fiBh9u5kcRYJSMaMOCCwQ",
                StartDate=new DateTime(2019, 9, 15),
                StartTime=new TimeSpan(13, 0, 0),
                EndDate=new DateTime(2019, 9, 17),
                Language= Enums.LanguageType.Pl,
                EndTime=new TimeSpan(9, 0, 0),
                HasAccomodationBooked=true,
                AccomodationId= "ChIJ0f0UBWVv5kcRgbSDqFRn5iw",
                PreferedTravelModes= preferedTravelModes,
                MaxWalkingKmsPerDay=20,
                DistanceTypePreference= DistanceTypePreference.MediumDistances,
                PricePreference= PricePreference.MediumPrices,
                FoodPreference= FoodPreference.Mixed,
                AverageSleep=8,
                AtractionPopularityPreference= AtractionPopularityPreference.MostPopular,
                AtractionDurationPreference= AtractionDurationPreference.Medium,
                SortedPlanElements=sorted,
                PreferedPlanElements= prefered
            };

        }

        public static PlanForm CreatePlanForm(this CreatePlanInput inputDto)
        {
            return new PlanForm(inputDto.PlaceName, inputDto.PlaceId, inputDto.StartDate, inputDto.StartTime, inputDto.EndDate, inputDto.EndTime,
                inputDto.Language, inputDto.HasAccomodationBooked, inputDto.AccomodationId, inputDto.PreferedTravelModes, inputDto.MaxWalkingKmsPerDay.Value, inputDto.DistanceTypePreference,
                inputDto.PricePreference, inputDto.FoodPreference, inputDto.AverageSleep, inputDto.AtractionPopularityPreference, inputDto.AtractionDurationPreference, inputDto.SortedPlanElements, inputDto.PreferedPlanElements);
        }
    }
}
