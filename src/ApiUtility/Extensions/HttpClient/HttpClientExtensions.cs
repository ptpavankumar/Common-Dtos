using System.Net.Http.Headers;
using ApiUtility.Common;
using ApiUtility.Extensions.HttpContext;

namespace ApiUtility.Extensions.HttpClient
{
    public static class HttpClientExtensions
    {
        public static void SetDefaultPlatformHeaders(this System.Net.Http.HttpClient httpClient,
            Microsoft.AspNetCore.Http.HttpContext context, bool includeTenant = true)
        {
            httpClient.DefaultRequestHeaders.Clear();

            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(CorePlatformConstants.ContentType.Json));

            httpClient.DefaultRequestHeaders.Add(CorePlatformConstants.HeaderKeys.Authorization,
                context.GetBearerToken());

            httpClient.DefaultRequestHeaders.Add(CorePlatformConstants.HeaderKeys.XCorePlatformCorrelationId,
                context.GetCorrelationId());

            if (includeTenant)
                httpClient.DefaultRequestHeaders.Add(CorePlatformConstants.HeaderKeys.XCoreplatformTenantId,
                    context.GetTenantId());
        }
    }
}