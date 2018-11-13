
namespace CloudAPI.Helpers
{
    public static class Constants
    {
        public const string FileUploadPath = nameof(FileUploadPath);
        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string Rol = "rol", Id = "id";
            }

            public static class JwtClaims
            {
                public const string ApiAccess = "api_access";
            }
        }
    }
}
