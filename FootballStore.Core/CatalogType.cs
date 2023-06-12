using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Core
{
    public sealed class CatalogType
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public CatalogType(string type)
        {
            Type = type;
        }
    }
}