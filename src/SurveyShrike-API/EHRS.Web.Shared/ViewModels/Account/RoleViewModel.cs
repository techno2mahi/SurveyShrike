﻿namespace EHRS.Web.Shared.Models
{
    public class RoleViewModel
    {
        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>The role identifier.</value>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>The name of the role.</value>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the role description.
        /// </summary>
        /// <value>The role description.</value>
        public string RoleDescription { get; set; }
    }
}
