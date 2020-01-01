using System.Collections.Generic;
using System.Web.Http;
using EHRS.Shared;
using WebApiThrottle;
using EHRS.Shared.Caching;

namespace EHRS.IdentityServer.Controllers
{
    [RoutePrefix("api/identity" + AppConstants.ConfigurationKeys.ApiVersion + "/health")]// this is the base http://localhost:59974/api/listing
    public class HealthApiController : BaseApiController
    {
        private readonly ICacheManager _cacheManager;
        public HealthApiController(ICacheManager cacheManager)
        {
            this._cacheManager = cacheManager;
        }

        [Route("GetThrottle")]
        [EnableThrottling(PerMinute = 3)]
        public IEnumerable<string> GetThrottle()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("GetError")]
        public IEnumerable<string> GetError()
        {
            try
            {
                var ab = 2 + 3 - 5;
                var a = 2 / ab;
            }
            catch (System.Exception ex)
            {
                ExceptionManager.HandleException(ex);
            }

            return new string[] { "Check error in the logs folder" };
        }

        [Route("dbconnectionstatus")]
        public string GetDBConnectionStatus()
        {
            var status = "";
            try
            {
                var _repo = new AuthRepository();
                var userId = _repo.FindByUserIdAsync("sfsafsadfsdfssdf-sfd-sd-fdsf");
                status = userId != null ? "OK" : "Not OK";
            }
            catch (System.Exception ex)
            {
                ExceptionManager.HandleException(ex);
            }

            return status;
        }

        [Route("status")]
        public string GetStatus()
        {
            var status = "OK";

            return status;
        }

     
    }
}
