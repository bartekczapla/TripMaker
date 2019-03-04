using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.ExternalServices.Entities
{
    public class GooglePlaceType
    {
        public GooglePlaceType(string name, GooglePlaceTypeCategory type)
        {
            Name = name;
            Type = type;
        }
        public string Name { get; set; }
        public GooglePlaceTypeCategory Type { get; set; }
    }

    public static class GooglePlaceTypes
    {

        public static ICollection<GooglePlaceType> Table =new Collection<GooglePlaceType>
        {
              new GooglePlaceType("accounting", GooglePlaceTypeCategory.None),
              new GooglePlaceType("airport", GooglePlaceTypeCategory.None),
              new GooglePlaceType("amusement_park", GooglePlaceTypeCategory.None),
              new GooglePlaceType("aquarium", GooglePlaceTypeCategory.None),
              new GooglePlaceType("art_gallery", GooglePlaceTypeCategory.None),
              new GooglePlaceType("atm", GooglePlaceTypeCategory.None),
              new GooglePlaceType("bakery", GooglePlaceTypeCategory.None),
              new GooglePlaceType("bank", GooglePlaceTypeCategory.None),
              new GooglePlaceType("bar", GooglePlaceTypeCategory.None),
              new GooglePlaceType("beauty_salon", GooglePlaceTypeCategory.None),
              new GooglePlaceType("bicycle_store", GooglePlaceTypeCategory.None),
              new GooglePlaceType("book_store", GooglePlaceTypeCategory.None),
              new GooglePlaceType("bowling_alley", GooglePlaceTypeCategory.None),
              new GooglePlaceType("bus_station", GooglePlaceTypeCategory.None),
              new GooglePlaceType("cafe", GooglePlaceTypeCategory.None),                           
              new GooglePlaceType("campground", GooglePlaceTypeCategory.None),
              new GooglePlaceType("car_dealer", GooglePlaceTypeCategory.None),
              new GooglePlaceType("car_rental", GooglePlaceTypeCategory.None),
              new GooglePlaceType("car_repair", GooglePlaceTypeCategory.None),
              new GooglePlaceType("car_wash", GooglePlaceTypeCategory.None),
              new GooglePlaceType("casino", GooglePlaceTypeCategory.None),
              new GooglePlaceType("cemetery", GooglePlaceTypeCategory.None),
              new GooglePlaceType("church", GooglePlaceTypeCategory.None),
              new GooglePlaceType("city_hall", GooglePlaceTypeCategory.None),
              new GooglePlaceType("clothing_store", GooglePlaceTypeCategory.None),
              new GooglePlaceType("convenience_store", GooglePlaceTypeCategory.None),
              new GooglePlaceType("courthouse", GooglePlaceTypeCategory.None),
              new GooglePlaceType("dentist", GooglePlaceTypeCategory.None),
              new GooglePlaceType("department_store", GooglePlaceTypeCategory.None),
              new GooglePlaceType("doctor", GooglePlaceTypeCategory.None),
              new GooglePlaceType("electrician", GooglePlaceTypeCategory.None),
              new GooglePlaceType("electronics_store", GooglePlaceTypeCategory.None),
              new GooglePlaceType("embassy", GooglePlaceTypeCategory.None),
              new GooglePlaceType("fire_station", GooglePlaceTypeCategory.None),
              new GooglePlaceType("florist", GooglePlaceTypeCategory.None),
              new GooglePlaceType("funeral_home", GooglePlaceTypeCategory.None),
              new GooglePlaceType("furniture_store", GooglePlaceTypeCategory.None),
              new GooglePlaceType("gas_station", GooglePlaceTypeCategory.None),
              new GooglePlaceType("gym", GooglePlaceTypeCategory.None),
              new GooglePlaceType("hair_care", GooglePlaceTypeCategory.None),
              new GooglePlaceType("hardware_store", GooglePlaceTypeCategory.None),
              new GooglePlaceType("hindu_temple", GooglePlaceTypeCategory.None),
              new GooglePlaceType("home_goods_store", GooglePlaceTypeCategory.None),
              new GooglePlaceType("hospital", GooglePlaceTypeCategory.None),
              new GooglePlaceType("insurance_agency", GooglePlaceTypeCategory.None),
              new GooglePlaceType("jewelry_store", GooglePlaceTypeCategory.None),
              new GooglePlaceType("laundry", GooglePlaceTypeCategory.None),
              new GooglePlaceType("lawyer", GooglePlaceTypeCategory.None),
              new GooglePlaceType("library", GooglePlaceTypeCategory.None),
              new GooglePlaceType("liquor_store", GooglePlaceTypeCategory.None),
              new GooglePlaceType("local_government_office", GooglePlaceTypeCategory.None),
              new GooglePlaceType("locksmith", GooglePlaceTypeCategory.None),
              new GooglePlaceType("lodging", GooglePlaceTypeCategory.None),
              new GooglePlaceType("meal_delivery", GooglePlaceTypeCategory.None),
              new GooglePlaceType("meal_takeaway", GooglePlaceTypeCategory.None),
              new GooglePlaceType("mosque", GooglePlaceTypeCategory.None),
              new GooglePlaceType("movie_rental", GooglePlaceTypeCategory.None),
              new GooglePlaceType("movie_theater", GooglePlaceTypeCategory.None),
              new GooglePlaceType("moving_company", GooglePlaceTypeCategory.None),
              new GooglePlaceType("museum", GooglePlaceTypeCategory.None),
              new GooglePlaceType("night_club", GooglePlaceTypeCategory.None),
              new GooglePlaceType("painter", GooglePlaceTypeCategory.None),
              new GooglePlaceType("park", GooglePlaceTypeCategory.None),
              new GooglePlaceType("parking", GooglePlaceTypeCategory.None),
              new GooglePlaceType("pet_store", GooglePlaceTypeCategory.None),
              new GooglePlaceType("pharmacy", GooglePlaceTypeCategory.None),
              new GooglePlaceType("physiotherapist", GooglePlaceTypeCategory.None),
              new GooglePlaceType("plumber", GooglePlaceTypeCategory.None),
              new GooglePlaceType("police", GooglePlaceTypeCategory.None),
              new GooglePlaceType("post_office", GooglePlaceTypeCategory.None),
              new GooglePlaceType("real_estate_agency", GooglePlaceTypeCategory.None),
              new GooglePlaceType("restaurant", GooglePlaceTypeCategory.None),
              new GooglePlaceType("roofing_contractor", GooglePlaceTypeCategory.None),
              new GooglePlaceType("rv_park", GooglePlaceTypeCategory.None),
              new GooglePlaceType("school", GooglePlaceTypeCategory.None),
              new GooglePlaceType("shoe_store", GooglePlaceTypeCategory.None),
              new GooglePlaceType("shopping_mall", GooglePlaceTypeCategory.None),
              new GooglePlaceType("spa", GooglePlaceTypeCategory.None),
              new GooglePlaceType("stadium", GooglePlaceTypeCategory.None),
              new GooglePlaceType("storage", GooglePlaceTypeCategory.None),
              new GooglePlaceType("store", GooglePlaceTypeCategory.None),
              new GooglePlaceType("subway_station", GooglePlaceTypeCategory.None),
              new GooglePlaceType("supermarket", GooglePlaceTypeCategory.None),
              new GooglePlaceType("synagogue", GooglePlaceTypeCategory.None),
              new GooglePlaceType("taxi_stand", GooglePlaceTypeCategory.None),
              new GooglePlaceType("train_station", GooglePlaceTypeCategory.None),
              new GooglePlaceType("transit_station", GooglePlaceTypeCategory.None),
              new GooglePlaceType("travel_agency", GooglePlaceTypeCategory.None),
              new GooglePlaceType("veterinary_care", GooglePlaceTypeCategory.None),
              new GooglePlaceType("zoo", GooglePlaceTypeCategory.None)
        };
    }
}
