using EHRS.Shared;

namespace EHRS.DAC.ServiceHelper
{
    public static class WebServiceUrl
    {
             private static readonly string tokenServiceUrl = AppConstants.ConfigurationKeys.TokenServiceUrl;

        /// <summary>
        /// Function to get Token Service url
        /// </summary>
        /// <returns></returns>
        public static string TokenServiceUrl()
        {
            return tokenServiceUrl;
        }

        #region Encryption/decryption service urls

        /// <summary>
        /// function to fetch url used for encrypting data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Encrypt(string data)
        {
            return "";// todo string.Format(ServiceUrl.Encryption, encryptdecryptServiceUrl, data);
        }

        /// <summary>
        /// function to fetch url used for decrypting data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Decrypt(string data)
        {
            return "";// todo string.Format(ServiceUrl.Decryption, encryptdecryptServiceUrl, data);
        }
        #endregion

    }
}
