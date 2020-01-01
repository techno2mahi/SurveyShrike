using System.Diagnostics.CodeAnalysis;

namespace EHRS.Shared
{
    public static class ValidationConstants
    {        
        public const string DateFormatMMddyyyy = "MM/dd/yyyy";

        public const string DefaultErrorKey = "Server Error";

        public const string DefaultErrorMessage = "Internal server error!";

        public static class RegEx
        {
            /// <summary>
            /// Regular expression for email validation 
            /// </summary>
            public const string Email = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
            public const string Alphabets = @"^([a-zA-Z]+\s)*[a-zA-Z]+$";
            public const string MobileNumber = @"^\d{10}$";
        }

        /// <summary>
        /// Constant for account releted constants
        /// </summary>
        public static class Account
        { 
                public const int PasswordMinimumLength = 8; 
 
        }

        public static class File
        {
            public const int FileTitleMinLength = 1;

            public const int FileTitleMaxLength = 100;

        }
    }
}