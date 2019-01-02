using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OA_WebBackEnd.Utilities
{
    public static class Settings
    {
        private static readonly string APP_SETTINGS = "appsettings.json";
        private static IConfiguration _configuration;
        public static IConfiguration Configuration
        {
            get
            {
                if(_configuration == null)
                    _configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile(APP_SETTINGS)
                   .AddEnvironmentVariables()
                   .Build();

                return _configuration;
            }
        }


        public static T GetConfiguration<T>(string key) {
            T converted = default(T);
            try
            {
                converted = (T)Convert.ChangeType(Configuration[key], typeof(T));
            }catch(Exception e)
            {
                return converted;
            }

            return converted;
        }
    }
}
