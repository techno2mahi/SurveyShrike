using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web; 

namespace EHRS.IdentityServer.Helpers
{
    public class AuthorizationHelper : IAuthorizationHelper
    {
        public string  ClientExistsAndActive()
        {
            return "Yes Client Exists";
        } 
    }
}