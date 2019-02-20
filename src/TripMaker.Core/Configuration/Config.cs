using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.Configuration
{
    public static class Config
    {
        public static string GoogleApiKey
        {
            get { return ConfigUtil.GetAppConfigSetting("GoogleApiKey"); }
        }
    }
}
