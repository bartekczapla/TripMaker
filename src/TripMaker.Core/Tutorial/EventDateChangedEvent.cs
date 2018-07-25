using Abp.Events.Bus.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.Tutorial
{
    public class EventDateChangedEvent : EntityEventData<Event>
    {
        public EventDateChangedEvent(Event entity)
            : base(entity)
        {
        }
    }
}
