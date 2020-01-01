using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System;
using EHRS.Web.Shared.Models;
using System.Collections.Generic;
using EHRS.Shared;

namespace EHRS.IdentityServer.Controllers
{
    /// <summary>
    /// The Roles api controller.
    /// </summary>
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/identity" + AppConstants.ConfigurationKeys.ApiVersion + "/roles")]
    public class RolesController : BaseApiController
    {

        [HttpGet]
        [Route("GetAllRoles")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult GetAllRoles()
        {
            List<RoleViewModel> roleModels = new List<RoleViewModel>();
            var roles = this.AppRoleManager.Roles;
            var count = 1;
            foreach (var role in roles)
            {
                if (role.Name == "Admin")
                    continue;
                roleModels.Add(new RoleViewModel
                {
                    RoleId = count,
                    RoleName = role.Name
                });
                count++;
            }

            return Ok(roleModels);
        }


        /// <summary>
        /// Adds user to the role
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [Route("AddUserToRole")]
        [HttpPost]
        public async Task<IHttpActionResult> AddUserToRole(ChangeRoleViewModel changeRoleViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appUser = await this.AppUserManager.FindByNameAsync(changeRoleViewModel.UserName);

            if (appUser == null)
            {
                ModelState.AddModelError("", String.Format("User: {0} does not exists", changeRoleViewModel.UserName));
            }

            if (!this.AppUserManager.IsInRole(appUser.Id, changeRoleViewModel.RoleName))
            {
                IdentityResult result = await this.AppUserManager.AddToRoleAsync(appUser.Id, changeRoleViewModel.RoleName);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", String.Format("User: {0} could not be added to role", changeRoleViewModel.UserName));
                }
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }
    }

}
