using System.Linq;

namespace ApiUtility.Extensions.Uri
{
    public static class UriExtensions
    {
        public static System.Uri Combine(this System.Uri uri, params string[] paths)
        {
            var combinedPath = paths.Aggregate(uri.ToString(), (v1, v2) => $"{v1.TrimEnd('/')}/{v2.TrimStart('/')}");
            return new System.Uri(combinedPath);
        }
    }
}
