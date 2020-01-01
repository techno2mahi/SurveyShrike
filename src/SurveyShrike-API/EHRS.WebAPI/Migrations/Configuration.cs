using System.Collections.Generic;
using EHRS.WebAPI.Helpers;

namespace EHRS.WebAPI.Migrations
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
        { 
            //Add Clients here
        }
    }
}
