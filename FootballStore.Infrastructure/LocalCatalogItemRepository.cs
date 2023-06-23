using FootballStore.Core.Interfaces;
using FootballStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Infrastructure
{
    public sealed class LocalCatalogItemRepository : IRepository<CatalogItem>
    {
        private static List<CatalogItem> _catalogItems = new List<CatalogItem>
        {
            new (1, "Ball", "ForSojhuhhuccer", 14.3M,
            "/images/products/1662144889_2-kartinkof-club-p-novie-i-krasivie-kartinki-myach-futbolnii-4.jpg"),
            new(2, "Ball", "ForSoccer", 13.3M,
            "/images/products/1662144892_3-kartinkof-club-p-novie-i-krasivie-kartinki-myach-futbolnii-6.jpg" ),
            new(3, "Ball", "ForSoccer", 12.2M,
            "/images/products/1662144894_5-kartinkof-club-p-novie-i-krasivie-kartinki-myach-futbolnii-8.jpg")

        };

        public List<CatalogItem> GetAll()
        {
            return _catalogItems;
        }

        public CatalogItem? GetById(int id)
        {
            var item = _catalogItems.FirstOrDefault(_=>_.Id==id);
            return item;
        }

        public void Update(CatalogItem entity)
        {
            var existingItem = GetById(entity.Id);

            if (existingItem != null)
            {
                int index = _catalogItems.IndexOf(existingItem);
                _catalogItems[index] = entity;
            }

        }
    }
}
