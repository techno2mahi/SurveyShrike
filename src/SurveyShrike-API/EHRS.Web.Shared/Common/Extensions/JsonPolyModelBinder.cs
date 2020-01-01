using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using Newtonsoft.Json;
using System.Net.Http;

namespace EHRS.Web.Shared.Common.Extensions
{
    /// <summary>
    /// 
    /// http://stackoverflow.com/questions/14124189/can-i-pass-an-interface-based-object-to-an-mvc-4-webapi-post
    /// </summary>
    public class JsonPolyModelBinder : IModelBinder
    {
        readonly JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var content = actionContext.Request.Content;
            string json = content.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject(json, bindingContext.ModelType, settings);
            bindingContext.Model = obj;
            return true;
        }
    }
}
