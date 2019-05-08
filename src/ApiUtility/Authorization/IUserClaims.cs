using System;
using System.Collections.Generic;

namespace ApiUtility.Authorization
{
    public interface IUserClaims
    {
        List<string> Audiences { get; }
        List<string> Scopes { get; }
        Guid? UserId { get; }
        List<string> GetClaimValuesByType(string type);
    }
}