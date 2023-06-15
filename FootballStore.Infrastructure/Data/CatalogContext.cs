using FootballStore.Core.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Infrastructure.Data
{
    public sealed class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {

        }

        DbSet<CatalogItemDto> catalogItemDtos { get; set; }
        DbSet<CatalogBrandDto> catalogBrandDtos { get; set; }
        DbSet<CatalogTypeDto> catalogTypeDtos { get; set; }
    }
}