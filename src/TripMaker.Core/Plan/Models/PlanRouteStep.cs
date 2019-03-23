using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities.Common;

namespace TripMaker.Plan.Models
{
    [Table("PlanRouteSteps")]
    public class PlanRouteStep : Entity
    {
        public const int MaxManeuverLength = 64;
        public const int MaxHtmlLength = 64 * 1024; //64KB

        public virtual int Distance { get; protected set; }

        public virtual int Duration { get; protected set; }

        public virtual double StartStepLat { get; protected set; }

        public virtual double StartStepLng { get; protected set; }

        public virtual double EndStepLat { get; protected set; }

        public virtual double EndStepLng { get; protected set; }

        [MaxLength(MaxHtmlLength)]
        public virtual string HtmlInstruction { get; protected set; }

        public virtual GoogleTravelMode TravelMode { get; protected set; }

        [MaxLength(MaxManeuverLength)]
        public virtual string Maneuver { get; protected set; }

        [ForeignKey("PlanRouteId")]
        public virtual PlanRoute PlanRoute { get; protected set; }
        public virtual int PlanRouteId { get; protected set; }

        public PlanRouteStep(int planRouteId, int distance, int duration, double startStepLat, double startStepLng, double endStepLat, double endStepLng,   GoogleTravelMode travelMode, string htmlInstruction, string maneuver)
        {
            PlanRouteId = planRouteId;
            Distance = distance;
            Duration = duration;
            StartStepLat = startStepLat;
            StartStepLng = startStepLng;
            EndStepLat = endStepLat;
            EndStepLng = endStepLng;
            TravelMode = travelMode;
            HtmlInstruction = htmlInstruction;
            Maneuver = maneuver;
        }
    }
}
