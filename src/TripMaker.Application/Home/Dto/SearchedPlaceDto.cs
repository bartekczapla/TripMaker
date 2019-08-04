using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TripMaker.Home.Models;

namespace TripMaker.Home.Dto
{
    public class SearchedPlaceDto
    {
        public string PlaceId { get; set; }

        public string PlaceName { get; set; }

        public int SearchCount { get; set; }

        public string Photo { get; set; }

    }
}
