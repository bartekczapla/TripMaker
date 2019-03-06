using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TripMaker.Enums
{
    public enum GoogleTravelMode
    {
        [Description("driving")]
        Driving=0,
        [Description("walking")]
        Walking =1,
        [Description("bicycling")]
        Bicycling =2,
        [Description("transit")]
        Transit =3
    }
}
