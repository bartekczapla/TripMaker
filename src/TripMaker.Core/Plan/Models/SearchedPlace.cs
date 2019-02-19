using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace TripMaker.Plan
{
    [Table("SearchedPlace")]
    public class SearchedPlace : Entity, IHasCreationTime
    {
        public const int MaxTitleLength = 512;
        public const int MaxDescriptionLength = 64 * 1024; //64KB

        [Required]
        [MaxLength(MaxTitleLength)]
        public virtual string PlaceId { get; set; }

        [MaxLength(MaxTitleLength)]
        public virtual string PlaceName { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public SearchedPlace()
        {
            CreationTime = Clock.Now;
        }

        public SearchedPlace(string placeId, string placeName)
            :this()
        {
            PlaceId = placeId;
            PlaceName = placeName ;
        }

    }
}
