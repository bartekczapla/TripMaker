using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace TripMaker.Configuration
{
    public static class ConfigUtil
    {
        /// <summary>
        ///  Utility method to retrieve configuration setting values.
        /// </summary>
        /// <param name="configKey">Configuration Settings key to retrieve.</param>
        /// <returns>empty string if key is null</returns>
        public static string GetAppConfigSetting(string configKey)
        {
            return ConfigurationManager.AppSettings[configKey] ?? string.Empty;
        }

    }
}
