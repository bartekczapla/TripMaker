using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.Configuration
{
    public static class Config
    {
        public static string GooglePlaceApiKey
        {
            get { return ConfigUtil.GetAppConfigSetting("GooglePlaceApiKey"); }
        }
    }
}
