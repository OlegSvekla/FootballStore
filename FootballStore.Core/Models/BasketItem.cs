using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Core.Models
{
    public sealed class BasketItem
    {
        public int Id { get; set; }
        public decimal UnitPrice { get; private set; }
        public int Quanitity { get; private set; }
        public int CatalogItemId { get; private set; }
        public int BasketId { get; private set; }

        public BasketItem()
        {
            
        }

        public BasketItem(int catalogItemId, int quantity, decimal unitPrice)
        {
            CatalogItemId = catalogItemId;
            UnitPrice = unitPrice;
            SetQuantity(quantity);
        }

        public void SetQuantity(int quantity)
        {
            Quanitity = quantity;
        }

        public void AddQuantity(int quantity)
        {
            Quanitity += quantity;
        }
    }
}
