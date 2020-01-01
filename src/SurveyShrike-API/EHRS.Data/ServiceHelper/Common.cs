using System;
using System.Collections.Generic;
using System.Linq;
using EHRS.DAC;
using EHRS.Shared; 
using EHRS.Shared.Factories;
using System.Net.Http;
using EHRS.DAC.ServiceHelper;

namespace EHRS.DAC
{
    public static class Common
    {
        /// <summary>
        /// Encrypt string using Service Method.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Encrypt(string data)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(data))
            {
                //result = WebHttpClient.HttpRequest<string>(HttpMethod.Get, WebServiceUrl.Encrypt(data), null);
            }
            return result;
        }

        /// <summary>
        /// Decrypt string using Service Method.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Decrypt(string data)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(data))
            {
                //result = WebHttpClient.HttpRequest<string>(HttpMethod.Get, WebServiceUrl.Decrypt(data), null);
            }
            return result;
        }

        /// <summary>
        /// Function to fill service's ImportUser DTO 
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public static Dictionary<string, string> generateImportUserDTO(Int64 incidentId)
        {

            //object result = new 
            //      {
            //          entityType = (int)EIS.Shared.EntityType.Incident,//1
            //          entityValue = incidentId,//1
            //          moduleId = (int)EIS.Shared.Module.SSP,//1
            //          siteId = 1
            //      };

            Dictionary<string, string> queryStringParams = new Dictionary<string, string>();
            //queryStringParams.Add("entityType", ((int)EIS.Shared.EntityType.Incident).ToString());
            queryStringParams.Add("entityValue", (incidentId).ToString());
          //  queryStringParams.Add("moduleId", ((int)EIS.Shared.Module.SSP).ToString());
            queryStringParams.Add("siteId", (1).ToString());
            return queryStringParams;

        }



    }

 

    public class Metadata<T> where T : class
    {
        public T[] value { get; set; }
        public int TotalRecordsCount { get; set; }
    }


    public class MetadataSingleValue<T> where T : class
    {
        public T value { get; set; }
    }
}
