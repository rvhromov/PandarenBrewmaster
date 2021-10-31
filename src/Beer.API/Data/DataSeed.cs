using System;
using Beer.API.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Beer.API.Data
{
    public static class DataSeed
    {
        public static void PopulateDb(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<MongoDbContext>();

            if (dbContext is null || dbContext.Beers.Find(b => true).Any())
            {
                Console.WriteLine("We already have data");
                return;
            }
                
            Console.WriteLine("Seeding Data...");
                
            dbContext.Beers.InsertMany(new []
            {
                // Light
                new Entities.Beer {Name = "Bud Light", Type = BeerType.Light },
                new Entities.Beer {Name = "Paulaner", Type = BeerType.Light },
                new Entities.Beer {Name = "Budweiser Budvar", Type = BeerType.Light },
                new Entities.Beer {Name = "Corona Light", Type = BeerType.Light },
                new Entities.Beer {Name = "Heineken Light", Type = BeerType.Light },
                
                // Dark
                new Entities.Beer {Name = "Dunkel", Type = BeerType.Dark },
                new Entities.Beer {Name = "Guinness Draught", Type = BeerType.Dark },
                new Entities.Beer {Name = "Velkopopovicky Kozel", Type = BeerType.Dark },
                new Entities.Beer {Name = "Varvar", Type = BeerType.Dark },
                new Entities.Beer {Name = "Lvivske Rizdvyane", Type = BeerType.Dark },
                
                // Ale
                new Entities.Beer {Name = "Hitachino White Ale", Type = BeerType.Ale },
                new Entities.Beer {Name = "4 Pines", Type = BeerType.Ale },
                new Entities.Beer {Name = "Furphy", Type = BeerType.Ale },
                new Entities.Beer {Name = "Coopers", Type = BeerType.Ale },
                new Entities.Beer {Name = "Stone & Wood", Type = BeerType.Ale },
                
                // Red
                new Entities.Beer {Name = "La Trappe Quadrupel", Type = BeerType.Red },
                new Entities.Beer {Name = "Chimay Red Cap", Type = BeerType.Red },
                new Entities.Beer {Name = "Boon Kriek", Type = BeerType.Red },
                new Entities.Beer {Name = "Petrus Red", Type = BeerType.Red },
                new Entities.Beer {Name = "Lindemans Framboise", Type = BeerType.Red }
            });
        }
    }
}