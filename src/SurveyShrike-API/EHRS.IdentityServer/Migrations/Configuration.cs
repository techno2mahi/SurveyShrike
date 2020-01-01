using System.Collections.Generic;
using EHRS.IdentityServer.Helpers;

namespace EHRS.IdentityServer.Migrations
{
    using System.Data.Entity.Migrations;
    using Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }



        protected override void Seed(AuthContext context)
        {/*
            if (context.Clients.Count() > 0)
            {
                return;
            }

            context.Clients.AddRange(BuildClientsList());
            context.SaveChanges();*/
        }

     
    }
}
