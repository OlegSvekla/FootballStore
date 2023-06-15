using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Core.DTOs
{
    public sealed class CatalogItemDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public int CatalogTypeId { get; set; }

        public CatalogTypeDto? CatalogType { get; set; }

        public int CatalogBrandId { get; set; }

        public CatalogBrandDto CatalogBrand { get; set; }

        public CatalogItemDto(int catalogTypeId,
        int catalogBrandId,
        string description,
        string name,
        decimal price,
        string pictureUrl)
        {
            CatalogTypeId = catalogTypeId;
            CatalogBrandId = catalogBrandId;
            Description = description;
            Name = name;
            Price = price;
            PictureUrl = pictureUrl;
        }
    }
}