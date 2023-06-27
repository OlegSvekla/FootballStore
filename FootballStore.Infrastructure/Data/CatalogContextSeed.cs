using Azure.Core;
using FootballStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext catalogContext, ILogger logger, int retry = 0)
        {
            var retryForEvilability = retry;
            try
            {
                if(!await catalogContext.CatalogBrands.AnyAsync())
                {
                    await catalogContext.AddRangeAsync(GetPreConfigureBrands());
                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.CatalogTypes.AnyAsync())
                {
                    await catalogContext.AddRangeAsync(GetPreConfigureTypes());
                    await catalogContext.SaveChangesAsync();  
                }

                if (!await catalogContext.CatalogItems.AnyAsync())
                {
                    await catalogContext.AddRangeAsync(GetPreConfigureItems());
                    await catalogContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                if(retryForEvilability >= 10) throw;
                                                    
                retryForEvilability++;
                logger.LogError(ex.Message);
                await SeedAsync(catalogContext, logger, retryForEvilability);
            }
        }

        private static IEnumerable<CatalogItem> GetPreConfigureItems()
        {
            return new List<CatalogItem>()
            {
                new(1,1, "BallAdidas1", "Desctiption", 14.3M,"/images/products/BallAdidas1.jpg"),
                new(1,1, "BallAdidas2", "Desctiption", 13.3M,"/images/products/BallAdidas2.jpg" ),
                new(1,1, "BallAdidas3", "Desctiption", 12.2M,"/images/products/BallAdidas3.jpg"),
                new(1,1, "BallAdidas4", "Desctiption", 12.2M,"/images/products/BallAdidas4.jpg"),
                new(1,1, "BallAdidas5", "Desctiption", 12.2M,"/images/products/BallAdidas5.jpg"),
                new(1,1, "BallAdidas6", "Desctiption", 12.2M,"/images/products/BallAdidas6.jpg"),

                new(1,2, "BallNike1", "Desctiption", 12.2M,"/images/products/BallNike1.jpg"),
                new(1,2, "BallNike2", "Desctiption", 12.2M,"/images/products/BallNike2.jpg"),
                new(1,2, "BallNike3", "Desctiption", 12.2M,"/images/products/BallNike3.jpg"),

                new(2,1, "ShoesAdidas1", "Desctiption", 12.2M,"/images/products/ShoesAdidas1.jpg"),
                new(2,1, "ShoesAdidas2", "Desctiption", 12.2M,"/images/products/ShoesAdidas2.jpg"),
                new(2,1, "ShoesAdidas3", "Desctiption", 12.2M,"/images/products/ShoesAdidas3.jpg"),
                new(2,1, "ShoesAdidas4", "Desctiption", 12.2M,"/images/products/ShoesAdidas4.jpg"),

                new(2,2, "ShoesNike1", "Desctiption", 12.2M,"/images/products/ShoesNike1.jpg"),
                new(2,2, "ShoesNike2", "Desctiption", 12.2M,"/images/products/ShoesNike2.jpg"),
                new(2,2, "ShoesNike3", "Desctiption", 12.2M,"/images/products/ShoesNike3.jpg"),
                new(2,2, "ShoesNike4", "Desctiption", 12.2M,"/images/products/ShoesNike4.jpg"),
                new(2,2, "ShoesNike5", "Desctiption", 12.2M,"/images/products/ShoesNike5.jpg")

            };
        }

        private static IEnumerable<CatalogBrand> GetPreConfigureBrands()
        {
            return new List<CatalogBrand>()
            {
                new ("Adidas"),
                new ("Nike"),
                new ("Puma"),
                new ("Reebok"),
                new ("UnderArmour"),
                new ("NewBalance"),
                new ("Anta")
            };
        }

        private static IEnumerable<CatalogType> GetPreConfigureTypes()
        {
            return new List<CatalogType>()
            {
                new ("Balls"),
                new ("Shoes"),
                new ("Jerseys"),
                new ("ShinGuards"),
                new ("Socks"),
                new ("Gloves"),
                new ("Hats"),
                new ("Shorts"),
                new ("CompressionWear"),
                new ("TrainingEquipment"),
                new ("Accessories"),
            };
        }
    }
}