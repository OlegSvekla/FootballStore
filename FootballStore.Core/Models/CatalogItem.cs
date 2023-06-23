using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Core.Models
{
    public sealed class CatalogItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public CatalogType? CatalogType { get; set; }
        public CatalogBrand? CatalogBrand { get; set; }

        public CatalogItem(int id, string name, string description, decimal price, string pictureUrl)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            PictureUrl = pictureUrl;
        }

        public void UpdateDetails(CatalogItemDetails details)
        {
            Name = details.Name;
            Price = details.Price;
        }

        public readonly struct CatalogItemDetails
        {
            public string? Name { get; }
            public decimal Price { get; }

            public CatalogItemDetails(string? name, decimal price)
            {
                Name = name;
                Price = price;
            }
        }
    }
}
