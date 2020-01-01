using EHRS.Shared;
using EHRS.IdentityServer.Entities;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EHRS.IdentityServer.Helpers;
using EHRS.IdentityServer.Models;

namespace EHRS.IdentityServer.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // to be used for native truested clients
            string clientId = string.Empty;
            string clientSecret = string.Empty;
            Client client = null;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                //Remove the comments from the below line context.SetError, and invalidate context 
                context.Validated();
                //context.SetError("invalid_clientId", "ClientId should be sent.");
                return Task.FromResult<object>(null);
            }

            using (AuthRepository _repo = new AuthRepository())
            {
                client = _repo.FindClient(context.ClientId);
            }

            if (client == null)
            {
                context.SetError("invalid_clientId", string.Format("Client '{0}' is not registered in the system.", context.ClientId));
                return Task.FromResult<object>(null);
            }

            if (client.ApplicationType == Models.ApplicationTypes.NativeConfidential)//todo
            {
                if (string.IsNullOrWhiteSpace(clientSecret))
                {
                    context.SetError("invalid_clientId", "Client secret should be sent.");
                    return Task.FromResult<object>(null);
                }
                else
                {
                    if (client.Secret != Helper.GetHash(clientSecret))//todo check the logic
                    {
                        context.SetError("invalid_clientId", "Client secret is invalid.");
                        return Task.FromResult<object>(null);
                    }
                }
            }

            if (!client.Active)
            {
                context.SetError("invalid_clientId", "Client is inactive.");
                return Task.FromResult<object>(null);
            }

            context.OwinContext.Set<string>("as:clientAllowedOrigin", client.AllowedOrigin);
            context.OwinContext.Set<string>("as:clientRefreshTokenLifeTime", client.RefreshTokenLifeTime.ToString());

            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin") ?? "*";
            ApplicationUser user = new ApplicationUser();
            var claimsIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            var concatenatedRoles = "";
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });
            AspNetUserProperty userProperty;
            using (AuthRepository _repo = new AuthRepository())
            {
                if (TokenIdentityHelper.IsCredentialForSingleClick(context.Password))
                {
                    var userId = TokenIdentityHelper.GetUserIdSingleClickSignInToken(context.Password);
                    user = await _repo.FindByUserIdAsync(userId);
                }
                else
                {
                    user = await _repo.FindUser(context.UserName, context.Password);
                }

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
                else if (!user.IsActive || _repo.IsLockedOut(user.Id))
                {
                    context.SetError("blocked_user", "Your account is disabled.");
                    return;
                }

                var userRoles = await _repo.FindRolesAsync(user.Id);
                foreach (var role in userRoles)
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
                }
                concatenatedRoles = string.Join(",", userRoles);

                //Add user property
                userProperty = await _repo.FindUserProperty(user.Id);

                //addingclaims
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.FirstName));
                claimsIdentity.AddClaim(new Claim(GlobalConstants.Account.ClaimTypes.UserName, user.UserName));
                claimsIdentity.AddClaim(new Claim(GlobalConstants.Account.ClaimTypes.Subject, user.Id));
                claimsIdentity.AddClaim(new Claim(GlobalConstants.Account.ClaimTypes.Issuer, GlobalConstants.EhrsIssuerUri));
            }

            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                {
                    "as:client_id", (context.ClientId == null) ? string.Empty : context.ClientId
                }
            };
            properties.Add("userName", context.UserName);
            properties.Add("firstName", user.FirstName);
            properties.Add("roles", concatenatedRoles);

            var authProps = new AuthenticationProperties(properties);
            var ticket = new AuthenticationTicket(claimsIdentity, authProps);

            context.Validated(ticket);
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.ClientId;

            if (originalClient != currentClient)
            {
                context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
                return Task.FromResult<object>(null);
            }

            // Change auth ticket for refresh token requests
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);

            var newClaim = newIdentity.Claims.Where(c => c.Type == "newClaim").FirstOrDefault();
            if (newClaim != null)
            {
                newIdentity.RemoveClaim(newClaim);
            }
            newIdentity.AddClaim(new Claim("newClaim", "newValue"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

    }
}