using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TripMaker.Enums
{
    public enum GoogleRestrictions
    {
        none=0,
        [Description("tolls")]
        tolls=1,
        [Description("highways")]
        highways =2,
        [Description("ferries")]
        ferries =3,
        [Description("indoor")]
        indoor =4
    }
}
