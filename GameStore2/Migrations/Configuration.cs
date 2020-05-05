namespace GameStore2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GameStore2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GameStore2.Models.ApplicationDbContext context)
        {
            context.Qualities.AddOrUpdate(r => r.Type,
              new Models.Quality { Type = "Excellent" },
              new Models.Quality { Type = "Good" },
              new Models.Quality { Type = "Poor" },
              new Models.Quality { Type = "Bad" }
              );
        }
    }
}
