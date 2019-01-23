using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.ExternalServices.GooglePlace
{
    public abstract class BaseGooglePlaceApiClient
    {
        //FIELDS

        //Basic
        protected static string Address_Field = "formatted_address";
        protected static string Geometry_Field = "geometry";
        protected static string Icon_Field = "icon";
        protected static string Id_Field = "id";
        protected static string Name_Field = "name";
        protected static string Closed_Field = "permanently_closed";
        protected static string Photos_Field = "photos";
        protected static string PlaceId_Field = "place_id";
        protected static string PlusCode_Field = "plus_code";
        protected static string Scope_Field = "scope";
        protected static string Types_Field = "types";

        //Contact
        protected static string OpeningHours_Field = "opening_hours";

        //Atmosphere
        protected static string PriceLevel_Field = "price_level";
        protected static string Rating_Field = "rating";


        //ADDITIONAL FIELDS FOR GOOGLE PLACE DETAILS

        //Basic
        protected static string Address_component_Field = "address_component";
        protected static string Adr_address_Field = "adr_address";
        protected static string Alt_id_Field = "alt_id";
        protected static string Type_Field = "type";
        protected static string Url_Field = "url";
        protected static string Vicinity_Field = "vicinity";

        //Contact
        protected static string Formatted_phone_number_Field = "formatted_phone_number";
        protected static string Website_Field = "website";

        //Atmosphere
        protected static string Review_Field = "review";

        //PLACE TYPES Table1
        protected static string Accounting_Type = "accounting";
        protected static string Airport_Type = "airport";
        protected static string Amusement_park_Type = "amusement_park";
        protected static string Aquarium_Type = "aquarium";
        protected static string Art_gallery_Type = "art_gallery";
        protected static string Atm_Type = "atm";
        protected static string Bakery_Type = "bakery";
        protected static string Bank_Type = "bank";
        protected static string Bar_Type = "bar";
        protected static string Beauty_salon_Type = "beauty_salon";
        protected static string Bicycle_store_Type = "bicycle_store";
        protected static string Book_store_Type = "book_store";
        protected static string Bowling_alley_Type = "bowling_alley";
        protected static string Bus_station_Type = "bus_station";
        protected static string Cafe_Type = "cafe";
        protected static string Campground_Type = "campground";
        protected static string Car_dealer_Type = "car_dealer";
        protected static string Car_rental_Type = "car_rental";
        protected static string Car_repair_Type = "car_repair";
        protected static string Car_wash_Type = "car_wash";
        protected static string Casino_Type = "casino";
        protected static string Cemetery_Type = "cemetery";
        protected static string Church_Type = "church";
        protected static string City_hall_Type = "city_hall";
        protected static string Clothing_store_Type = "clothing_store";
        protected static string Convenience_store_Type = "convenience_store";
        protected static string Courthouse_Type = "courthouse";
        protected static string Dentist_Type = "dentist";
        protected static string Department_store_Type = "department_store";
        protected static string Doctor_Type = "doctor";
        protected static string Electrician_Type = "electrician";
        protected static string Electronics_store_Type = "electronics_store";
        protected static string Embassy_Type = "embassy";
        protected static string Fire_station_Type = "fire_station";
        protected static string Florist_Type = "florist";
        protected static string Funeral_home_Type = "funeral_home";
        protected static string Furniture_store_Type = "furniture_store";
        protected static string Gas_station_Type = "gas_station";
        protected static string Gym_Type = "gym";
        protected static string Hair_care_Type = "hair_care";
        protected static string Hardware_store_Type = "hardware_store";
        protected static string Hindu_temple_Type = "hindu_temple";
        protected static string Home_goods_store_Type = "home_goods_store";
        protected static string Hospital_Type = "hospital";
        protected static string Insurance_agency_Type = "insurance_agency";
        protected static string Jewelry_store_Type = "jewelry_store";
        protected static string Laundry_Type = "laundry";
        protected static string Lawyer_Type = "lawyer";
        protected static string Library_Type = "library";
        protected static string Liquor_store_Type = "liquor_store";
        protected static string Local_government_office_Type = "local_government_office";
        protected static string Locksmith_Type = "locksmith";
        protected static string Lodging_Type = "lodging";
        protected static string Meal_delivery_Type = "meal_delivery";
        protected static string Meal_takeaway_Type = "meal_takeaway";
        protected static string Mosque_Type = "mosque";
        protected static string Movie_rental_Type = "movie_rental";
        protected static string Movie_theater_Type = "movie_theater";
        protected static string Moving_company_Type = "moving_company";
        protected static string Museum_Type = "museum";
        protected static string Night_club_Type = "night_club";
        protected static string Painter_Type = "painter";
        protected static string Park_Type = "park";
        protected static string Parking_Type = "parking";
        protected static string Pet_store_Type = "pet_store";
        protected static string Pharmacy_Type = "pharmacy";
        protected static string Physiotherapist_Type = "physiotherapist";
        protected static string Plumber_Type = "plumber";
        protected static string Police_Type = "police";
        protected static string Post_office_Type = "post_office";
        protected static string Real_estate_agency_Type = "real_estate_agency";
        protected static string Restaurant_Type = "restaurant";
        protected static string Roofing_contractor_Type = "roofing_contractor";
        protected static string Rv_park_Type = "rv_park";
        protected static string School_Type = "school";
        protected static string Shoe_store_Type = "shoe_store";
        protected static string Shopping_mall_Type = "shopping_mall";
        protected static string Spa_Type = "spa";
        protected static string Stadium_Type = "stadium";
        protected static string Storage_Type = "storage";
        protected static string Store_Type = "store";
        protected static string Subway_station_Type = "subway_station";
        protected static string Supermarket_Type = "supermarket";
        protected static string Synagogue_Type = "synagogue";
        protected static string Taxi_stand_Type = "taxi_stand";
        protected static string Train_station_Type = "train_station";
        protected static string Transit_station_Type = "transit_station";
        protected static string Travel_agency_Type = "travel_agency";
        protected static string Veterinary_care_Type = "veterinary_care";
        protected static string Zoo_Type = "zoo";

    }
}
