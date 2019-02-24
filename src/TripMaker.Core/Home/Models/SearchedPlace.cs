using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace TripMaker.Home.Models
{
    [Table("SearchedPlaces")]
    public class SearchedPlace : Entity
    {
        public const int MaxTitleLength = 512;
        public const int MaxDescriptionLength = 64 * 1024; //64KB

        [Required]
        [MaxLength(MaxTitleLength)]
        public virtual string PlaceId { get; protected set; }

        [MaxLength(MaxTitleLength)]
        public virtual string PlaceName { get; protected set; }

        [Range(1, int.MaxValue)]
        public virtual int SearchCount { get; protected set; }


        public SearchedPlace(string placeId, string placeName, int searchCount = 1)
        {
            PlaceId = placeId;
            PlaceName = placeName;
            SearchCount = searchCount;
        }

        public void AddCount()
        {
            SearchCount = SearchCount + 1;
        }

    }
}
