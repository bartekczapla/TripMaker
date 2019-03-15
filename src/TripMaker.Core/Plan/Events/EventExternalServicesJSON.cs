using Abp.Events.Bus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.ExternalServices.Entities.Models;

namespace TripMaker.Plan.Events
{
    public class EventExternalServicesJSON : EntityEventData<ExternalServicesJSON>
    {
        public EventExternalServicesJSON(ExternalServicesJSON entity)
            : base(entity)
        {
        }
    }
}
