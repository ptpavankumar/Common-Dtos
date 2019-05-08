namespace ApiUtility.Authorization
{
    public static class Constants
    {
        public static class Scopes
        {
            public const string Platform = "platform";
            public const string PlatformInternal = "platform_internal";
            public const string PlatformUser = "platform_user";
            public const string PlatformApplication = "platform_application";
        }

        public static class Policies
        {
            public const string Internal = "internal";
            public const string User = "user";
            public const string Application = "application";
            public const string InternalOrApplication = "internalorapplication";
        }

        public static class Keys
        {
            public const string UserId = "userid";
            public const string Scope = "scope";
            public const string Audience = "aud";
            public const string User = "user";
            public const string Default = "default";
        }
    }
}