using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TripMaker.Home.Models
{
    [Table("PlacePhotos")]
    public class PlacePhoto : Entity
    {
        public const int MaxTitleLength = 512;
        public const int MaxDescriptionLength = 64 * 1024; //64KB

        [Required]
        [MaxLength(MaxTitleLength)]
        public virtual string PlaceId { get; protected set; }

        [MaxLength(MaxTitleLength)]
        public virtual string PhotoReference { get; protected set; }

        [MaxLength(MaxDescriptionLength)]
        public virtual string Photo { get; protected set; }

        public virtual int? MaxWidth { get; protected set; }

        public virtual int? MaxHeight { get; protected set; }

        public PlacePhoto(string placeId, string photoReference, string photo)
        {
            PlaceId = placeId;
            PhotoReference = photoReference;
            Photo = photo;
        }
    }
}
