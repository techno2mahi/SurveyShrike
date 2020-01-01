using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using EHRS.Shared;

namespace EHRS.Web.Shared.Common
{
    public static class Token
    {
        /// <summary>
        /// Function to Get new token
        /// </summary>
        /// <returns></returns>
        public static bool GetNewToken(string emailAddress, string password)
        {
            bool isTokenGenerated = false;

            HttpClient httpClient = new HttpClient();
            var form = new Dictionary<string, string>
               {
                   {"grant_type","password" },
                   {"username", emailAddress},
                   {"password", password},
                   {"client_id", "safsadfsadfsdf"},
                   {"client_secret", "123123123@abc"}
               };
            HttpResponseMessage responseMessage;
            responseMessage = httpClient.PostAsync(AppConstants.ConfigurationKeys.WebApiUrl + "/token", new FormUrlEncodedContent(form)).Result;
            var token = responseMessage.Content.ReadAsAsync<Models.Token>(new[] { new JsonMediaTypeFormatter() });

            //OperationResult<ITokenDTO> result = commonBdc.GetToken(emailAddress, password, null);
            if (token.Result != null)
            {
                SessionStateManager<UserInfo>.Data.Token = token.Result;
                isTokenGenerated = true;
            }


            return isTokenGenerated;
        }

        /// <summary>
        /// get token after validating
        /// </summary>
        /// <returns></returns>
        public static ITokenDTO GetToken()
        {
            // ValidateAndGetToken();
            return SessionStateManager<UserInfo>.Data.Token;
        }



    }
}
