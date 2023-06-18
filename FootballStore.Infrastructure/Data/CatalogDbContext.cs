using FootballStore.Core.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Infrastructure.Data
{
    public sealed class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {

        }

        public DbSet<CatalogItemDto> CatalogItemDtos { get; set; }
        public DbSet<CatalogBrandDto> CatalogBrandDtos { get; set; }
        public DbSet<CatalogTypeDto> CatalogTypeDtos { get; set; }
    }
}