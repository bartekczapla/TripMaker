using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TripMaker.Enums
{
    public enum TransitRoutingPreference
    {
        none=0,
        [Description("less_walking")]
        less_walking =1,
        [Description("fewer_transfers")]
        fewer_transfers =2
    }
}
