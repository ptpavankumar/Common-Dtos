using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace ApiUtility.Authorization
{
    public class UserClaims : IUserClaims
    {
        private readonly HttpContext _httpContext;

        public UserClaims(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public List<string> Audiences => GetClaims(Constants.Keys.Audience)?.Select(x => x.Value).ToList();

        public List<string> Scopes => GetClaims(Constants.Keys.Scope)?.Select(x => x.Value).ToList();

        public Guid? UserId => GetUserId();

        public List<string> GetClaimValuesByType(string type)
        {
            try
            {
                return GetClaims(type).Select(x => x.Value).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private IEnumerable<Claim> GetClaims(string type)
        {
            return _httpContext.User.Claims
                .Where(x => string.Equals(x.Type, type, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        private Guid? GetUserId()
        {
            try
            {
                var userId = GetClaims(Constants.Keys.UserId).FirstOrDefault()?.Value;

                if (userId != null && Guid.TryParse(userId, out var id))
                    return id;

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}