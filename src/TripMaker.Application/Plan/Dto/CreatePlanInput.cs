using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TripMaker.Enums;
using TripMaker.Enums.PlanFormEnums;
using TripMaker.Plan.Dto;

namespace TripMaker.Plan
{
   // [AutoMapTo(typeof(PlanForm))]
    public class CreatePlanInput : ICustomValidate,  IShouldNormalize
    {
        // 1) Miejsce i czas
        [Required]
        [MaxLength(80)]
        public string PlaceName { get; set; }
        [Required]
        [MaxLength(80)]
        public string PlaceId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        [Required]
        public bool HasAccomodationBooked { get; set; }
        [MaxLength(80)]
        public string AccomodationId { get; set; }

        //public PlanAccomodationDto PlanAccomodation { get; set; }
        public LanguageType Language { get; set; }

        // 2) Przemieszczanie się
        public IList<GoogleTravelMode> PreferedTravelModes { get; set; }
        public int? MaxWalkingKmsPerDay { get; set; }
        public DistanceTypePreference DistanceTypePreference { get; set; }

        // 3) Główne preferencje
        [Required]
        public PricePreference PricePreference { get; set; }
        [Required]
        public FoodPreference FoodPreference { get; set; }
        [Required]
        [Range(5, 12)]
        public int AverageSleep { get; set; }
        [Required]
        public AtractionPopularityPreference AtractionPopularityPreference { get; set; }
        [Required]
        public AtractionDurationPreference AtractionDurationPreference { get; set; }

        // 4) Cele podróży
        [Required]
        public IList<PlanElementType> SortedPlanElements { get; set; }
        [Required]
        public IList<PlanElementType> PreferedPlanElements { get; set; }


        public void AddValidationErrors(CustomValidationContext context)
        {
            if (DateTime.Compare(StartDate.Add(StartTime), EndDate.Add(EndTime)) >=0 )
            {
                context.Results.Add(new ValidationResult("Data początkowa nie może być później niż końcowa!"));
            }
            if (DateTime.Compare(DateTime.Now, StartDate.Add(StartTime)) >= 0)
            {
                context.Results.Add(new ValidationResult("Data początkowa nie może być w przeszłości!"));
            }
            if (HasAccomodationBooked && String.IsNullOrEmpty(AccomodationId))
            {
                context.Results.Add(new ValidationResult($"Brak Id dla miejsca zakwaterowania!"));
            }
            if (PreferedTravelModes == null || PreferedTravelModes.Count == 0)
            {
                context.Results.Add(new ValidationResult("Brak preferowanych środków transportu!"));
            }
        }

        public void Normalize()
        {
            if (SortedPlanElements == null) SortedPlanElements = new List<PlanElementType>();
            if (PreferedPlanElements == null) PreferedPlanElements = new List<PlanElementType>();
            if (!MaxWalkingKmsPerDay.HasValue) MaxWalkingKmsPerDay = 0;
        }

        public override string ToString()
        {
            return string.Format("[CreatePlanInput > PlaceName = {0}, StartDate = {1}]", PlaceName, StartDate);
        }
    }
}

//        [Range(1,long.MaxValue)]
//        [Required]
// [StringLength(Event.MaxTitleLength)] 