namespace ApiUtility.Common
{
    public static class CorePlatformConstants
    {
        public static class HeaderKeys
        {
            public const string XCorePlatformCorrelationId = "x-coreplatform-correlationid";
            public const string XCoreplatformTenantId = "x-coreplatform-tenantid";
            public const string Authorization = "Authorization";
        }

        public static class ContentType
        {
            public const string Json = "application/json";
        }
    }
}
