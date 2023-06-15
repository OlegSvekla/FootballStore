using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Core
{
    public sealed class CatalogBrand
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public CatalogBrand(string brand)
        {
            Brand = brand;
        }
    }
}