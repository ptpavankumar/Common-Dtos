using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApiUtility.Helpers.Extensions
{
    public static class TestAuthExtensions
    {
        public static AuthenticationBuilder AddTestAuth(this AuthenticationBuilder builder,
            Action<TestAuthOptions> configureOptions)
        {
            return builder.AddScheme<TestAuthOptions, TestAuthHandler>("TestScheme", "TestScheme", configureOptions);
        }
    }

    public class TestAuthOptions : AuthenticationSchemeOptions
    {
    }

    internal class TestAuthHandler : AuthenticationHandler<TestAuthOptions>
    {
        public TestAuthHandler(IOptionsMonitor<TestAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var identity = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "Scope", "Platform", "Test-Issuer"),
                    new Claim("scope", "test", "test")
                },
                "Test-Issuer",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            Context.User.AddIdentity(identity);

            return AuthenticateResult.NoResult();
        }
    }
}