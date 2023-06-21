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

        public CatalogItem(string name, string description, decimal price, string pictureUrl)
        {
            Name = name;
            Description = description;
            Price = price;
            PictureUrl = pictureUrl;
        }
    }
}
