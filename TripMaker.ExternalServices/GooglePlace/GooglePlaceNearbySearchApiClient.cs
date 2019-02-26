﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TripMaker.Configuration;
using TripMaker.ExternalServices.Entities.GooglePlaceNearbySearch;
using TripMaker.ExternalServices.Interfaces.GooglePlace;

namespace TripMaker.ExternalServices.GooglePlace
{
    public class GooglePlaceNearbySearchApiClient : BaseGooglePlaceApiClient, IGooglePlaceNearbySearchApiClient
    {
        public HttpClient _httpClient;
        private static string GoogleApiKey;

        public GooglePlaceNearbySearchApiClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/place/nearbysearch/");
            _httpClient = httpClient;
            GoogleApiKey = Config.GoogleApiKey;
        }


        //Required parameters: 
        //-key
        //-location=lat,long
        //-radius={...meters} !not when rankby=distance

        //Optional parameters:
        //- language = {en, pl}
        //- keyword= {term to be matched against all content} !If rankby=distance
        //= minprice, maxprice= 0(affordable) to 4(expensive)
        //-name = {like keyword}
        //- opennow - return only now open places
        //- rankby={prominence, distance}  !prominence based on importance, distance based on distance from location, 
        // if rankby=distance is specified, then one or more of keyword, name, or type is required
        //- type= {result matching specified tyep} !only one !If rankby=distance
        //- pagetoken -Returns the next 20 results from a previously run search. Setting a pagetoken parameter will execute a search with the same parameters used previously



        public async Task<GooglePlaceNearbySearchRootObject> GetAllAsync(Location location, int radius)
        {
            var uri = $"json?location={location.lat},{location.lng}&radius={radius}&key={GoogleApiKey}";
            var resultJson = await _httpClient.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<GooglePlaceNearbySearchRootObject>(resultJson);
            result.resultJson = resultJson;
            return result;
        }

        public async Task<GooglePlaceNearbySearchRootObject> GetAllNearestByKeyWordAsync(Location location, string keyword)
        {
            var uri = $"json?location={location.lat},{location.lng}&rankby=distance&keyword={keyword}&key={GoogleApiKey}";
            var resultJson = await _httpClient.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<GooglePlaceNearbySearchRootObject>(resultJson);
            result.resultJson = resultJson;
            return result;
        }

        public async Task<GooglePlaceNearbySearchRootObject> GetAllNearestByTypeAsync(Location location, string type)
        {
            var uri = $"json?location={location.lat},{location.lng}&rankby=distance&type={type}&key={GoogleApiKey}";
            var resultJson = await _httpClient.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<GooglePlaceNearbySearchRootObject>(resultJson);
            result.resultJson = resultJson;
            return result;
        }

        public async Task<GooglePlaceNearbySearchRootObject> GetNextPageTokenAsync(string token)
        {
            var uri = $"json?pagetoken={token}y&key={GoogleApiKey}";
            var resultJson = await _httpClient.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<GooglePlaceNearbySearchRootObject>(resultJson);
            result.resultJson = resultJson;
            return result;
        }
    }
}
