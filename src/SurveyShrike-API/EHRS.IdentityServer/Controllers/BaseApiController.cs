using Microsoft.AspNet.Identity;
using System.Web.Http;
using System.Net.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using EHRS.IdentityServer.Infrastructure;
using EHRS.IdentityServer.Models;
using System.Net;
using EHRS.Web.Shared.Serializers;
using EHRS.Shared;

namespace EHRS.IdentityServer.Controllers
{
    public class BaseApiController : ApiController
    {
        private ModelFactory _modelFactory;
        private ApplicationUserManager _AppUserManager = null;
        private ApplicationRoleManager _AppRoleManager = null;
        protected readonly IJsonFieldsSerializer _jsonFieldsSerializer;
        public UserManager<ApplicationUser> UserManager { get; private set; }//todo move models to Web.Shared

        protected ApplicationUserManager AppUserManager
        {
            get
            {
                return _AppUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        protected ApplicationRoleManager AppRoleManager
        {
            get
            {
                return _AppRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }

        public BaseApiController()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            UserManager.DefaultAccountLockoutTimeSpan = System.TimeSpan.FromMinutes(30);//todo from config
            UserManager.UserValidator = new UserValidator<ApplicationUser>(UserManager)
            {
                AllowOnlyAlphanumericUserNames = true,// todo from config
                RequireUniqueEmail = true // todo from config
            };
            _jsonFieldsSerializer = new JsonFieldsSerializer();
        }

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(this.Request, this.AppUserManager);
                }
                return _modelFactory;
            }
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
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        protected IHttpActionResult Error(string propertyKey, string errorMessage = ValidationConstants.DefaultErrorMessage,
                                            bool setInModelState = false, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            HttpResponseMessage retVal;
            if (setInModelState && !string.IsNullOrWhiteSpace(propertyKey))
            {
                ModelState.AddModelError(propertyKey, errorMessage);
                retVal = Request.CreateErrorResponse(
                statusCode, ModelState);
            }
            else
            {
                retVal = Request.CreateErrorResponse(
                statusCode, errorMessage);
            }

            return ResponseMessage(retVal);
        }
    }
}