using Microsoft.AspNet.Identity;
using System.Web.Http;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using EHRS.Web.Shared.Models;
using EHRS.Web.Shared.ActionResults;
using EHRS.Web.Shared.Serializers;

namespace EHRS.WebAPI.Controllers
{
    public class BaseApiController : ApiController
    {
        protected readonly IJsonFieldsSerializer _jsonFieldsSerializer  ;
        public BaseApiController( )
        {
            _jsonFieldsSerializer = new JsonFieldsSerializer();
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        protected IHttpActionResult Error(HttpStatusCode statusCode = (HttpStatusCode)422, string propertyKey = "", string errorMessage = "")
        {
            var errors = new Dictionary<string, List<string>>();

            if (!string.IsNullOrEmpty(errorMessage) && !string.IsNullOrEmpty(propertyKey))
            {
                var errorsList = new List<string>() { errorMessage };
                errors.Add(propertyKey, errorsList);
            }

            foreach (var item in ModelState)
            {
                var errorMessages = item.Value.Errors.Select(x => x.ErrorMessage);

                List<string> validErrorMessages = new List<string>();

                if (errorMessages != null)
                {
                    validErrorMessages.AddRange(errorMessages.Where(message => !string.IsNullOrEmpty(message)));
                }

                if (validErrorMessages.Count > 0)
                {
                    if (errors.ContainsKey(item.Key))
                    {
                        errors[item.Key].AddRange(validErrorMessages);
                    }
                    else
                    {
                        errors.Add(item.Key, validErrorMessages.ToList());
                    }
                }
            }

            var errorsRootObject = new ErrorsRootObject()
            {
                Errors = errors
            };

            var errorsJson = _jsonFieldsSerializer.Serialize(errorsRootObject, null);

            return new ErrorActionResult(errorsJson, statusCode);
        }
    }
}