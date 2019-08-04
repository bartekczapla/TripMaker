using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.ExternalServices.Entities
{
    public class GooglePlaceType
    {
        public GooglePlaceType()
        {
            Name = String.Empty;
            Type = GooglePlaceTypeCategory.None;
        }

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
              new GooglePlaceType("accounting", GooglePlaceTypeCategory.Bank),
              new GooglePlaceType("airport", GooglePlaceTypeCategory.Airport),
              new GooglePlaceType("amusement_park", GooglePlaceTypeCategory.Entertainment),
              new GooglePlaceType("aquarium", GooglePlaceTypeCategory.Entertainment),
              new GooglePlaceType("art_gallery", GooglePlaceTypeCategory.Culture),
              new GooglePlaceType("atm", GooglePlaceTypeCategory.Bank),
              new GooglePlaceType("bakery", GooglePlaceTypeCategory.Food),
              new GooglePlaceType("bank", GooglePlaceTypeCategory.Bank),
              new GooglePlaceType("bar", GooglePlaceTypeCategory.Partying),
              new GooglePlaceType("beauty_salon", GooglePlaceTypeCategory.Relax),
              new GooglePlaceType("bicycle_store", GooglePlaceTypeCategory.Other_shop),
              new GooglePlaceType("book_store", GooglePlaceTypeCategory.Other_shop),
              new GooglePlaceType("bowling_alley", GooglePlaceTypeCategory.Entertainment),
              new GooglePlaceType("bus_station", GooglePlaceTypeCategory.City_communication),
              new GooglePlaceType("cafe", GooglePlaceTypeCategory.Restaurant),                           
              new GooglePlaceType("campground", GooglePlaceTypeCategory.None),
              new GooglePlaceType("car_dealer", GooglePlaceTypeCategory.None),
              new GooglePlaceType("car_rental", GooglePlaceTypeCategory.Car_rental),
              new GooglePlaceType("car_repair", GooglePlaceTypeCategory.None),
              new GooglePlaceType("car_wash", GooglePlaceTypeCategory.None),
              new GooglePlaceType("casino", GooglePlaceTypeCategory.Partying),
              new GooglePlaceType("cemetery", GooglePlaceTypeCategory.None),
              new GooglePlaceType("church", GooglePlaceTypeCategory.Sightseeing),
              new GooglePlaceType("city_hall", GooglePlaceTypeCategory.Sightseeing),
              new GooglePlaceType("clothing_store", GooglePlaceTypeCategory.Shopping),
              new GooglePlaceType("convenience_store", GooglePlaceTypeCategory.Food),
              new GooglePlaceType("courthouse", GooglePlaceTypeCategory.None),
              new GooglePlaceType("dentist", GooglePlaceTypeCategory.None),
              new GooglePlaceType("department_store", GooglePlaceTypeCategory.Shopping),
              new GooglePlaceType("doctor", GooglePlaceTypeCategory.None),
              new GooglePlaceType("electrician", GooglePlaceTypeCategory.None),
              new GooglePlaceType("electronics_store", GooglePlaceTypeCategory.None),
              new GooglePlaceType("embassy", GooglePlaceTypeCategory.None),
              new GooglePlaceType("fire_station", GooglePlaceTypeCategory.None),
              new GooglePlaceType("florist", GooglePlaceTypeCategory.None),
              new GooglePlaceType("funeral_home", GooglePlaceTypeCategory.None),
              new GooglePlaceType("furniture_store", GooglePlaceTypeCategory.None),
              new GooglePlaceType("gas_station", GooglePlaceTypeCategory.None),
              new GooglePlaceType("gym", GooglePlaceTypeCategory.Activity),
              new GooglePlaceType("hair_care", GooglePlaceTypeCategory.None),
              new GooglePlaceType("hardware_store", GooglePlaceTypeCategory.None),
              new GooglePlaceType("hindu_temple", GooglePlaceTypeCategory.Sightseeing),
              new GooglePlaceType("home_goods_store", GooglePlaceTypeCategory.Shopping),
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
              new GooglePlaceType("meal_takeaway", GooglePlaceTypeCategory.Food),
              new GooglePlaceType("mosque", GooglePlaceTypeCategory.None),
              new GooglePlaceType("movie_rental", GooglePlaceTypeCategory.None),
              new GooglePlaceType("movie_theater", GooglePlaceTypeCategory.Culture),
              new GooglePlaceType("moving_company", GooglePlaceTypeCategory.None),
              new GooglePlaceType("museum", GooglePlaceTypeCategory.Culture),
              new GooglePlaceType("night_club", GooglePlaceTypeCategory.Partying),
              new GooglePlaceType("painter", GooglePlaceTypeCategory.None),
              new GooglePlaceType("park", GooglePlaceTypeCategory.Activity),
              new GooglePlaceType("parking", GooglePlaceTypeCategory.None),
              new GooglePlaceType("pet_store", GooglePlaceTypeCategory.None),
              new GooglePlaceType("pharmacy", GooglePlaceTypeCategory.None),
              new GooglePlaceType("physiotherapist", GooglePlaceTypeCategory.None),
              new GooglePlaceType("plumber", GooglePlaceTypeCategory.None),
              new GooglePlaceType("police", GooglePlaceTypeCategory.None),
              new GooglePlaceType("post_office", GooglePlaceTypeCategory.None),
              new GooglePlaceType("real_estate_agency", GooglePlaceTypeCategory.None),
              new GooglePlaceType("restaurant", GooglePlaceTypeCategory.Restaurant),
              new GooglePlaceType("roofing_contractor", GooglePlaceTypeCategory.None),
              new GooglePlaceType("rv_park", GooglePlaceTypeCategory.None),
              new GooglePlaceType("school", GooglePlaceTypeCategory.None),
              new GooglePlaceType("shoe_store", GooglePlaceTypeCategory.Shopping),
              new GooglePlaceType("shopping_mall", GooglePlaceTypeCategory.Shopping),
              new GooglePlaceType("spa", GooglePlaceTypeCategory.Relax),
              new GooglePlaceType("stadium", GooglePlaceTypeCategory.Sightseeing),
              new GooglePlaceType("storage", GooglePlaceTypeCategory.None),
              new GooglePlaceType("store", GooglePlaceTypeCategory.None),
              new GooglePlaceType("subway_station", GooglePlaceTypeCategory.City_communication),
              new GooglePlaceType("supermarket", GooglePlaceTypeCategory.Food),
              new GooglePlaceType("synagogue", GooglePlaceTypeCategory.Sightseeing),
              new GooglePlaceType("taxi_stand", GooglePlaceTypeCategory.None),
              new GooglePlaceType("train_station", GooglePlaceTypeCategory.City_communication),
              new GooglePlaceType("transit_station", GooglePlaceTypeCategory.City_communication),
              new GooglePlaceType("travel_agency", GooglePlaceTypeCategory.None),
              new GooglePlaceType("veterinary_care", GooglePlaceTypeCategory.None),
              new GooglePlaceType("zoo", GooglePlaceTypeCategory.Entertainment),
              //additional
              new GooglePlaceType("food", GooglePlaceTypeCategory.Food),
              new GooglePlaceType("natural_feature", GooglePlaceTypeCategory.Sightseeing),
              new GooglePlaceType("point_of_interest", GooglePlaceTypeCategory.Sightseeing)
        };
    }
}
