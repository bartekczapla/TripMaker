using Abp.Events.Bus.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.Plan
{
    public class EventSearchPlace : EntityEventData<Plan>
    {
        public EventSearchPlace(Plan entity)
            : base(entity)
        {
        }
    }
}
