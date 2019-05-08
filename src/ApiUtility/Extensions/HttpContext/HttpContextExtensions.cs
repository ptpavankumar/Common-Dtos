using ApiUtility.Common;

namespace ApiUtility.Extensions.HttpContext
{
    public static class HttpContextExtensions
    {
        public static string GetBearerToken(this Microsoft.AspNetCore.Http.HttpContext context)
        {
            return context.Request.Headers[CorePlatformConstants.HeaderKeys.Authorization];
        }

        public static string GetTenantId(this Microsoft.AspNetCore.Http.HttpContext context)
        {
            return context.Request.Headers[CorePlatformConstants.HeaderKeys.XCoreplatformTenantId];
        }

        public static string GetHeaderValueByKey(this Microsoft.AspNetCore.Http.HttpContext context, string key)
        {
            return context.Request.Headers[key];
        }

        public static string GetCorrelationId(this Microsoft.AspNetCore.Http.HttpContext context)
        {
            if (context.Request.Headers.TryGetValue(CorePlatformConstants.HeaderKeys.XCorePlatformCorrelationId,
                out var correlationId) && !string.IsNullOrWhiteSpace(correlationId))
                return correlationId;

            return context.TraceIdentifier;
        }
    }
}