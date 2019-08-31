using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using TripMaker.Authorization.Users;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.Plan.Models;
using TripMaker.Validation;

namespace TripMaker.Plan
{
    [Table("Plans")]
    public class Plan : Entity
    {
        public const int MaxTitleLength = 128;

        [Required]
        [StringLength(MaxTitleLength)]
        public virtual string Name { get;  set; }

        public virtual double Latitude { get; set; }

        public virtual double Longitude { get; set; }

        [StringLength(MaxTitleLength)]
        public virtual string Address { get; set; }

        public virtual decimal? Rating { get; set; }

        public virtual decimal? TotalUserReviews { get; set; }

        [ForeignKey("PlanFormId")]
        public virtual PlanForm PlanForm { get;  set; }
        public virtual int? PlanFormId { get;  set; }

        [ForeignKey("UserId")]
        public virtual User User { get;  set; }
        public virtual long? UserId { get;  set; }

        [NotMapped]
        public string Photo { get; set; }

        [ForeignKey("PlanAccomodationId")]
        public virtual PlanAccomodation PlanAccomodation { get; set; }
        public virtual int? PlanAccomodationId { get; set; }

        [ForeignKey("PlanFormWeightVectorId")]
        public virtual PlanFormWeightVector PlanFormWeightVector { get; set; }
        public virtual int? PlanFormWeightVectorId { get; set; }

        [ForeignKey("PlanId")]
        public virtual ICollection<PlanElement> Elements { get;  set; }

        protected Plan()
        {

        }

        public Plan(string name, double lat, double lng , decimal? rating , decimal? totalUserReviews , string address)
            :this()
        {
            Name = name;
            Latitude = lat;
            Longitude = lng;
            Rating = rating;
            TotalUserReviews = totalUserReviews;
            Address = address;
            Elements = new Collection<PlanElement>();
        }

        [NotMapped]
        public Location StartLocation
        {
            get
            {
                return PlanForm.HasAccomodationBooked ? Location.Create(PlanAccomodation.Lat, PlanAccomodation.Lng) : Location.Create(Latitude, Longitude);
            }
        }

        [NotMapped]
        public PlanAssumptions Assumptions { get; set; }
    }
}


