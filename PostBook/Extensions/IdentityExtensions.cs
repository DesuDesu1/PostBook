namespace PostBook.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            if (httpContext == null)
            {
                return string.Empty;
            }
            return httpContext.User.Claims.Single(x => x.Type == "id").Value;
        }
    }
}
