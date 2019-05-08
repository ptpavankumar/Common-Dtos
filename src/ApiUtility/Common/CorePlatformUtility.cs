using System;

namespace ApiUtility.Common
{
    public static class CorePlatformUtility
    {
        public static string GetEnvironmentValue(string key, string defaultValue)
        {
            var envKey = key.Replace(@":", "_").ToUpper();
            var value = Environment.GetEnvironmentVariable(envKey);
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }
    }
}
