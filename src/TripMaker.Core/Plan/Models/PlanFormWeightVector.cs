using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.Plan.Models
{
    [Table("PlanFormWeightVectors")]
    public class PlanFormWeightVector: Entity
    {
        private static int NumberOfColumns => Enum.GetNames(typeof(WeightVectorLabel)).Length;

        [Required]
        public virtual decimal Price { get; set; }
        [Required]
        public virtual decimal Rating { get; set; }
        [Required]
        public virtual decimal Distance { get; set; }
        [Required]
        public virtual decimal Popularity { get; set; }
        [Required]
        public virtual decimal Entertainment { get; set; }
        [Required]
        public virtual decimal Relax { get; set; }
        [Required]
        public virtual decimal Activity { get; set; }
        [Required]
        public virtual decimal Culture { get; set; }
        [Required]
        public virtual decimal Sightseeing { get; set; }
        [Required]
        public virtual decimal Partying { get; set; }
        [Required]
        public virtual decimal Shopping { get; set; }


        /// <summary>
        /// We don't make constructor public and forcing to create events using <see cref="Create"/> method.
        /// But constructor can not be private since it's used by EntityFramework.
        /// Thats why we did it protected.
        /// </summary>
        protected PlanFormWeightVector()
        {

        }

        public static PlanFormWeightVector Create(WeightVector weightVector)
        {
            var planFormWeightVector = new PlanFormWeightVector
            {
                Price = weightVector.GetLabelValue(WeightVectorLabel.Price),
                Rating = weightVector.GetLabelValue(WeightVectorLabel.Rating),
                Distance = weightVector.GetLabelValue(WeightVectorLabel.Distance),
                Popularity = weightVector.GetLabelValue(WeightVectorLabel.Popularity),
                Entertainment = weightVector.GetLabelValue(WeightVectorLabel.Entertainment),
                Relax = weightVector.GetLabelValue(WeightVectorLabel.Relax),
                Activity = weightVector.GetLabelValue(WeightVectorLabel.Activity),
                Culture = weightVector.GetLabelValue(WeightVectorLabel.Culture),
                Sightseeing = weightVector.GetLabelValue(WeightVectorLabel.Sightseeing),
                Partying = weightVector.GetLabelValue(WeightVectorLabel.Partying),
                Shopping = weightVector.GetLabelValue(WeightVectorLabel.Shopping)
             };

            return planFormWeightVector;
        }
    }
}
