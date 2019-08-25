using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;
using TripMaker.Plan.Interfaces;
using TripMaker.Plan.Models;

namespace TripMaker.Plan
{
    public class WeightVectorProvider : IWeightVectorProvider
    {
        public WeightVector Generate(PlanForm planForm)
        {
            decimal TotalWeightSum = 1.0m;
            var weightVector = new WeightVector();
            weightVector.Values[0] = 0.3m;
            weightVector.Values[1] = 0.2m;
            weightVector.Values[2] = 0.1m;
            weightVector.Values[3] = 0.1m;
            weightVector.Values[4] = 0.1m;
            weightVector.Values[5] = 0.1m;
            weightVector.Values[6] = 0.1m;
            return weightVector;
        }
    }
}
//// 1) Miejsce i czas
//public virtual string PlaceName { get; set; }
//public virtual string PlaceId { get; set; }
//public virtual DateTime StartDate { get; set; }
//public virtual TimeSpan StartTime { get; set; }
//public virtual DateTime EndDate { get; set; }
//public virtual TimeSpan EndTime { get; set; }
//public virtual bool HasAccomodationBooked { get; set; }
//public virtual string AccomodationId { get; set; }
//public virtual LanguageType Language { get; set; }

//// 2) Przemieszczanie się
//public IList<GoogleTravelMode> PreferedTravelModes { get; set; }
//public virtual string PreferedTravelModesString { get; set; }
//public virtual int MaxWalkingKmsPerDay { get; set; }
//public virtual DistanceTypePreference DistanceTypePreference { get; set; }

//// 3) Główne preferencje
//public virtual PricePreference PricePreference { get; set; }
//public virtual FoodPreference FoodPreference { get; set; }
//public virtual int AverageSleep { get; set; }
//public virtual AtractionPopularityPreference AtractionPopularityPreference { get; set; }
//public virtual AtractionDurationPreference AtractionDurationPreference { get; set; }

//// 4) Cele podróży
//public IList<PlanElementType> SortedPlanElements { get; set; }
//public IList<PlanElementType> PreferedPlanElements { get; set; }
