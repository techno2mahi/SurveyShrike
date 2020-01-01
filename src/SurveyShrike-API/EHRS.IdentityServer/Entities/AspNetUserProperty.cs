using System;
using EHRS.IdentityServer.Models;
using System.ComponentModel.DataAnnotations;

namespace EHRS.IdentityServer.Entities
{
    public class AspNetUserProperty
    {
        [Key]
        public string UserId { get; set; }

        public Int64? ProfileMediaId { get; set; }

        public string FCMRegToken { get; set; }
        public Int16? Gender { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; } 
    }
}