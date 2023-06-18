using FootballStore.Core.DTOs;
using FootballStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FootballStore.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogDbContext catalogDbContext, ILogger logger, int retry = 0)
        {
            var retryForAvailbility = retry;

            try
            {
                if(!await catalogDbContext.CatalogItemDtos.AnyAsync())
                {
                    await catalogDbContext.AddRangeAsync(GetPreConfiguredItems());
                    await catalogDbContext.SaveChangesAsync();
                }
                if(!await catalogDbContext.CatalogBrandDtos.AnyAsync()) 
                {
                    await catalogDbContext.AddRangeAsync(GetPreConfigureBrands());
                    await catalogDbContext.SaveChangesAsync();
                }
                if(!await catalogDbContext.CatalogTypeDtos.AnyAsync())
                {
                    await catalogDbContext.AddRangeAsync(GetPreConfiguredTypes());
                    await catalogDbContext.SaveChangesAsync();
                }
            }

            catch (Exception ex)
            {

                if (retryForAvailbility >= 10) throw;
                {
                    retryForAvailbility++;

                    logger.LogError(ex.Message);
                    await SeedAsync(catalogDbContext, logger, retryForAvailbility);
                }
                throw;
            }
        }

        private static IEnumerable<CatalogItemDto> GetPreConfiguredItems()
        {
            return new List<CatalogItemDto>
            {
                new ( 1, 1, "Botts ", "Sit", 19.5M,
                "C:\\Users\\olegs\\source\\repos\\OlegSvekla\\FootballStore\\FootballStore\\FootballStore\\wwwroot\\images\\product\\boots\\Addidas\\RTLABC346301_16319840_1_v1.jpg"),
                new (2, 2, "bob", "LOL", 20.5M,
                "C:\\Users\\olegs\\source\\repos\\OlegSvekla\\FootballStore\\FootballStore\\FootballStore\\wwwroot\\images\\product\\boots\\Addidas\\RTLACB365001_18191717_1_v1.jpg")
            };
        }

        private static IEnumerable<CatalogTypeDto> GetPreConfiguredTypes()
        {
            return new List<CatalogTypeDto>
            {
                new("Boots"),
                new("balls")
            };
        }
        private static IEnumerable<CatalogBrandDto> GetPreConfigureBrands()
        { 
            return new List<CatalogBrandDto>
            {
                new CatalogBrandDto("Nike"),
                new("Addidas")
            };
        }

    }
}