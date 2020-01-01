using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity; 
using EHRS.IdentityServer.Entities;

namespace EHRS.IdentityServer
{
    public class AuthContext  : IdentityDbContext
    {
        public AuthContext(): base("SSConnection")
        {
        }
        public DbSet<Client> Clients { get; set; }

        public DbSet<AspNetUserProperty> AspNetUserProperties { get; set; }
    }
}