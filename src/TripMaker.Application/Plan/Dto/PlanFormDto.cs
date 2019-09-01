using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;
using TripMaker.Enums.PlanFormEnums;

namespace TripMaker.Plan.Dto
{
    [AutoMapFrom(typeof(PlanForm))]
    public class PlanFormDto
    {

        public string PlaceName { get; set; }

        public string PlaceId { get; set; }

        public DateTime StartDate { get; set; }

        public TimeSpan? StartTime { get; set; }

        public DateTime EndDate { get; set; }

        public TimeSpan? EndTime { get; set; }

        public bool HasAccomodationBooked { get; set; }

        public string AccomodationId { get; set; }

        public LanguageType Language { get; set; }

        public DateTime CreationTime { get; set; }

        public IList<GoogleTravelMode> PreferedTravelModes { get; set; }

        public string PreferedTravelModesString { get; set; }

        public int MaxWalkingKmsPerDay { get; set; }

        public DistanceTypePreference DistanceTypePreference { get; set; }

        public PricePreference PricePreference { get; set; }

        public FoodPreference FoodPreference { get; set; }

        public int AverageSleep { get; set; }

        public AtractionPopularityPreference AtractionPopularityPreference { get; set; }

        public AtractionDurationPreference AtractionDurationPreference { get; set; }

        public IList<PlanElementType> SortedPlanElements { get; set; }

        public string SortedPlanElementsString { get; set; }

        public IList<PlanElementType> PreferedPlanElements { get; set; }

        public string PreferedPlanElementsString { get; set; }

    }
}

