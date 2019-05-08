using Microsoft.AspNetCore.Authorization;

namespace ApiUtility.Authorization
{
    public static class AuthorizationOptions
    {
        public static void AddPlatformAuthorization(
            Microsoft.AspNetCore.Authorization.AuthorizationOptions authorizationOptions)
        {
            authorizationOptions.AddPolicy(Constants.Policies.Internal, builder =>
            {
                builder.RequireScope(Constants.Scopes.PlatformInternal);
            });

            authorizationOptions.AddPolicy(Constants.Policies.User, builder =>
            {
                builder.RequireScope(Constants.Scopes.PlatformUser);
            });

            authorizationOptions.AddPolicy(Constants.Policies.Application, builder =>
            {
                builder.RequireScope(Constants.Scopes.PlatformApplication);
            });

            authorizationOptions.AddPolicy(Constants.Policies.InternalOrApplication, builder =>
            {
                builder.RequireScope(Constants.Scopes.PlatformApplication, Constants.Scopes.PlatformInternal);
            });
        }

        public static void AddTestAuthorization(
            Microsoft.AspNetCore.Authorization.AuthorizationOptions options)
        {
            options.AddPolicy(Constants.Policies.Internal,
                builder => { builder.RequireClaim("scope", "test"); });

            options.AddPolicy(Constants.Policies.Application,
                builder => { builder.RequireClaim("scope", "test"); });

            options.AddPolicy(Constants.Policies.User,
                builder => { builder.RequireClaim("scope", "test"); });

            options.AddPolicy(Constants.Policies.InternalOrApplication,
                builder => { builder.RequireClaim("scope", "test"); });
        }
    }
}