namespace EHRS.DAC.ServiceHelper
{
    public class DACConstants
    {
        public struct SiteServiceColumnNames
        {
            public const string SiteId = "SiteId";
        }

        public struct TokenFields
        {
            public static readonly string Username = "username";
            public static readonly string SiteId = "SiteId";
            public static readonly string Password = "password";
            public static readonly string GrantType = "grant_type";
            public static readonly string RefreshToken = "refresh_token";
            public static readonly string AccessToken = "access_token";
            public static readonly string TokenType = "token_type";
            public static readonly string ExpiresIn = "expires_in";
            public static readonly string Issued = ".issued";
            public static readonly string Expires = ".expires";
            public static readonly string ConsumerKey = "client_id";
            public static readonly string ConsumerSecret = "client_secret";
            public static readonly string EntityType = "entityType";
            public static readonly string EntityValue = "entityValue";

            public static readonly string GrantType_RefreshToken = "refresh_token";
            public static readonly string GrantType_Password = "password";



            public static readonly string Token = "Token";
        }
    }
}
