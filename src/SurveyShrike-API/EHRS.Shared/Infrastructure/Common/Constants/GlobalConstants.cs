using System.Diagnostics.CodeAnalysis;

namespace EHRS.Shared
{
    public static class GlobalConstants
    {
        
        public const string EhrsIssuerUri = "https://YCompany.com/identity";//todo change a different name
        public const string LoaderImagePath = "\\Content\\Images\\ajaxloader.gif";
        public const string TokenEndPointPath = "/token"; 

        public const string DateFormatMMddyyyy = "MM/dd/yyyy";
        public const string FacebookProviderName = "Facebook";
        public const string GoogleProviderName = "Google";

        public const int HttpPageNotFoundErrorCode = 404;


        /// <summary>
        /// Constant for file table
        /// </summary>
        public static class Account
        {
            public static class ClaimTypes
            {
                public const string UserName = "username";
                public const string Issuer = "iss";
                public const string Subject = "sub";
                public const string SchoolId = "schoolid";
            }

            public static class Roles
            {
                public const string Admin = "Admin";
                public const string User = "User";
                public const string Operator = "Operator";
            }
        }

        public const int DefaultCreateId = -1;

        /// <summary>
        /// The Image Output Cache duration default is 30 minutes
        /// </summary>
        public const int ImageOutputCacheDuration = 1800;

        public const int DefaultIntValue = 0;

        public static class File
        {
            public const string DefaultFileExtensionName = "Unknown";
        }
    }
}