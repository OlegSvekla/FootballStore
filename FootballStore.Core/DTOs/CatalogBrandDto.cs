using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Core.DTOs
{
    public sealed class CatalogBrandDto
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public CatalogBrandDto(string brand)
        {
            Brand = brand;
        }
    }
}