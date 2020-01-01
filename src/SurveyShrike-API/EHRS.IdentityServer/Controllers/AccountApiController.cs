using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using EHRS.Shared;
using EHRS.Web.Shared.Models;
using EHRS.IdentityServer.Helpers;
using EHRS.IdentityServer.Models;

namespace EHRS.IdentityServer.Controllers
{
    /// <summary>
    /// Account Api Controller for all the account related end points
    /// </summary>
    [RoutePrefix("api/identity" + AppConstants.ConfigurationKeys.ApiVersion + "/account")]
    public class AccountApiController : BaseApiController
    {
        #region Properties

        private AuthRepository _repo = null;
        private readonly IAuthorizationHelper _authorizationHelper;

        public AccountApiController()
        {
            _repo = new AuthRepository();
        }

        #endregion

        #region Public

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterViewModel registerViewModel)
        {
            var user = GetApplicationUser(registerViewModel);

            try
            {
                IdentityResult result = await _repo.RegisterUser(user, registerViewModel.Password);
                if (!result.Succeeded)
                {
                    return GetIdentityErrorResult(result);
                }
            }
            catch (Exception ex)
            {

               
            }
            
            return Ok();
        }
 
        #endregion

        #region Private
 
        private IHttpActionResult GetIdentityErrorResult(IdentityResult result)
        {
            var errorMessage = result.Errors != null && result.Errors.Any() ? result.Errors.First() : ValidationConstants.DefaultErrorMessage;
            return Error(propertyKey: ValidationConstants.DefaultErrorKey, errorMessage: errorMessage);
        }
      
        private ApplicationUser GetApplicationUser(RegisterViewModel registerViewModel)
        {
            var appUser = new ApplicationUser()
            {
                UserName = registerViewModel.MobileNo,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.Email,
                MobileNo = registerViewModel.MobileNo,
                AddressLine1 = string.Empty,
                AddressLine2 = string.Empty,
                AreaId = string.Empty,
                CityId = 0,
                PinCode = 0,
                CreatedDate = DateTime.Now,
                IsActive = true,
                LockoutEnabled = false,
                LockoutEndDateUtc = DateTime.Now.AddYears(12),
                AccessFailedCount = 3
            };

            return appUser;
        }

        #endregion

        #region Protected

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}
