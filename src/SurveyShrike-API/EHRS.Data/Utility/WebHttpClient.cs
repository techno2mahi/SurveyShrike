using System;
using System.Net.Http;
using System.Net.Http.Headers; 

namespace EHRS.Shared
{
    public  class WebHttpClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="requestedVersion"></param>
        /// <returns></returns>
        public static HttpClient GetClient(string accessToken = null, string requestedVersion = null)
        {

            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(AppConstants.ConfigurationKeys.WebApiUrl);

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
            }

            if (requestedVersion != null)
            {
                // through a custom request header
                //client.DefaultRequestHeaders.Add("api-version", requestedVersion);

                // through content negotiation
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.expensetrackerapi.v" + requestedVersion + "+json"));
            }

            return httpClient;
        }
    }
}