using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using TripMaker.Enums;
using TripMaker.Enums.PlanFormEnums;
using TripMaker.Plan.Models;
using TripMaker.Validation;

namespace TripMaker.Plan
{
    [Table("PlanForms")]
    public class PlanForm : Entity, IHasCreationTime
    {
        public const int MaxTitleLength = 512;
        public const int ShortTitleLength = 50;

        // 1) Miejsce i czas
        [Required]
        [MaxLength(MaxTitleLength)]
        public virtual string PlaceName { get; set; }
        [Required]
        [MaxLength(MaxTitleLength)]
        public virtual string PlaceId { get; set; }
        [Required]
        public virtual DateTime StartDate { get; set; }
        [Required]
        public virtual TimeSpan StartTime { get; set; }
        [Required]
        public virtual DateTime EndDate { get; set; }
        [Required]
        public virtual TimeSpan EndTime { get; set; }
        [Required]
        public virtual bool HasAccomodationBooked { get; set; }
        [MaxLength(80)]
        public virtual string AccomodationId { get; set; }

        public virtual LanguageType Language { get;  set; }

        // 2) Przemieszczanie się
        [NotMapped]
        public IList<GoogleTravelMode> PreferedTravelModes { get; set; }
        [Required]
        [MaxLength(ShortTitleLength)]
        public virtual string PreferedTravelModesString { get; set; }
        [Required]
        public virtual int MaxWalkingKmsPerDay { get; set; }
        [Required]
        public virtual DistanceTypePreference DistanceTypePreference { get; set; }

        // 3) Główne preferencje
        [Required]
        public virtual PricePreference PricePreference { get; set; }
        [Required]
        public virtual FoodPreference FoodPreference { get; set; }
        [Required]
        [Range(5, 12)]
        public virtual int AverageSleep { get; set; }
        [Required]
        public virtual AtractionPopularityPreference AtractionPopularityPreference { get; set; }
        [Required]
        public virtual AtractionDurationPreference AtractionDurationPreference { get; set; }

        // 4) Cele podróży
        [NotMapped]
        public IList<PlanElementType> SortedPlanElements { get; set; }
        [Required]
        [MaxLength(ShortTitleLength)]
        public virtual string SortedPlanElementsString { get; set; }

        [NotMapped]
        public IList<PlanElementType> PreferedPlanElements { get; set; }
        [Required]
        [MaxLength(ShortTitleLength)]
        public virtual string PreferedPlanElementsString { get; set; }


        public virtual DateTime CreationTime { get; set; }

        protected PlanForm()
        {
            CreationTime = Clock.Now;
        }

        public PlanForm(string placeName, string placeId, DateTime startDate, TimeSpan startTime, DateTime endDate, TimeSpan endTime, LanguageType language, bool hasAccomodationBooked, string accomodationId,
                        IList<GoogleTravelMode> preferedTravelModes,int maxWalkingKmsPerDay, DistanceTypePreference distanceTypePreference,
                        PricePreference pricePreference, FoodPreference foodPreference, int averageSleep, AtractionPopularityPreference atractionPopularityPreference, AtractionDurationPreference atractionDurationPreference,
                        IList<PlanElementType> sortedPlanElements, IList<PlanElementType> preferedPlanElements)
            : this()
        {
            PlaceName = placeName;
            PlaceId = placeId;
            StartDate = startDate;
            StartTime = startTime;
            EndDate = endDate;
            EndTime = endTime;
            Language = language;
            HasAccomodationBooked = hasAccomodationBooked;
            AccomodationId = accomodationId;
            PreferedTravelModes = preferedTravelModes;
            PreferedTravelModesString = String.Join(';', preferedTravelModes.Select(x => (int)x).ToArray());
            MaxWalkingKmsPerDay = maxWalkingKmsPerDay;
            DistanceTypePreference = distanceTypePreference;
            PricePreference = PricePreference;
            FoodPreference = FoodPreference;
            AverageSleep = averageSleep;
            AtractionPopularityPreference = atractionPopularityPreference;
            AtractionDurationPreference = atractionDurationPreference;
            SortedPlanElements = sortedPlanElements;
            SortedPlanElementsString = String.Join(';', sortedPlanElements.Select(x=>(int)x).ToArray());
            PreferedPlanElements = preferedPlanElements;
            PreferedPlanElementsString = String.Join(';', preferedPlanElements.Select(x => (int)x).ToArray());
        }

        public bool IsDatesCorrect()
        {
            return DateTime.Compare(StartDate, Clock.Now) >= 0 && DateTime.Compare(StartDate, EndDate) <= 0;
        }
    }
}
