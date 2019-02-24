using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TripMaker.Home.Models;

namespace TripMaker.Home.Dto
{
    [AutoMapFrom(typeof(SearchedPlace))]
    public class SearchedPlaceDto
    {
        [Required]
        [MaxLength(SearchedPlace.MaxTitleLength)]
        public string PlaceId { get; set; }

        [MaxLength(SearchedPlace.MaxDescriptionLength)]
        public string PlaceName { get; set; }

        public int SearchCount { get; set; }

    }
}
