namespace GameStore2.Migrations
{
    using GameStore2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using GameStore2.Models;
using System.Web.UI.WebControls;

    internal sealed class Configuration : DbMigrationsConfiguration<GameStore2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GameStore2.Models.ApplicationDbContext context)
        {
            
            context.Qualities.AddOrUpdate(r => r.Type,
              new Models.Quality { Type = "Excellent" },
              new Models.Quality { Type = "Good" },
              new Models.Quality { Type = "Poor" },
              new Models.Quality { Type = "Bad" }
              );
            context.Categories.AddOrUpdate(r => r.CategoryName,
              new Models.Category { CategoryName = "Rhythm"},
              new Models.Category { CategoryName = "Roguelike" },
              new Models.Category { CategoryName = "Story" },
              new Models.Category { CategoryName = "Fps" },
              new Models.Category { CategoryName = "Musou" }
              );

            for (int i = 0; i < 20; i++) {
                context.Games.AddOrUpdate(r => r.Title,
                 new Models.Game { Title = "game"+i, CategoryId = i%5 + 1}
                 );
            }

            for (int i = 0; i < 100; i++)
            {
                context.Sales.AddOrUpdate(r => r.Id,
                 new Models.Sale { GameId = i%20 +1, price = i, QualityID = 1, Userid = "af89d9b0-7313-41df-9b2a-be417a05726a" /*test user */ }
                 );
            }



        }
    }
}
