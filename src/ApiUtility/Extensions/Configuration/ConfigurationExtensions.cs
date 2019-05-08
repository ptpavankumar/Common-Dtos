using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace ApiUtility.Extensions.Configuration
{
    public static class ConfigurationExtensions
    {
        public static string GetValue(this IConfiguration configuration, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return string.Empty;

            var environmentValue = GetEnvironmentValue(key);

            return !string.IsNullOrWhiteSpace(environmentValue)
                ? environmentValue
                : configuration.GetSection(key).Value;
        }

        public static List<string> GetList(this IConfiguration configuration, string key)
        {
            return configuration.GetValue(key).Split(",").ToList();
        }

        private static string GetEnvironmentValue(string key)
        {
            var envKey = key.Replace(@":", "_").ToUpper();
            return Environment.GetEnvironmentVariable(envKey);
        }
    }
}
