using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.ExternalServices.Entities.GooglePlaceDetails;
using TripMaker.ExternalServices.Interfaces.GooglePlace;
using TripMaker.Plan;

namespace TripMaker.ExternalServices.Core
{
    public class GooglePlaceDetailsInputFactory : IGooglePlaceDetailsInputFactory
    {

        //Required parameters: 
        //-key
        //-placeid  

        //Optional parameters:
        //- language = {en, pl}
        //- fields


        public GooglePlaceDetailsInput Create(PlanForm planForm)
        {
            throw new NotImplementedException();
        }
    }
}
