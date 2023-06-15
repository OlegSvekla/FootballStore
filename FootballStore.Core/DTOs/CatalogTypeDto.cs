using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Core.DTOs
{
    public sealed class CatalogTypeDto
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public CatalogTypeDto(string type)
        {
            Type = type;
        }
    }
}