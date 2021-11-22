using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Configuration;

namespace HRMS
{
    public class ConfigurationService
    {
        public static IConfigurationRoot Configuration;

        public static void SetConfiguration()
        {
            Configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();
        }

        public static T GetConfigurationValue<T>(string sectionName)
        {
            T @object = Configuration.GetSection(sectionName).Get<T>();
            return @object;
        }

        public static string GetConfigurationValue(string key)
        {
            string value = Configuration.GetValue<string>(key);
            return value;
        }
    }
}