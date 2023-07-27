using System.ComponentModel.DataAnnotations;

namespace FootballStore.Pages.Basket
{
    public sealed class BasketItemViewModel
    {
        public int Id { get; set; }

        public int CatalogItemId { get; set; }

        public string? ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal OldUnitPrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quanity must be bigger then 0")]

        public int Quanity { get; set; }

        public string? PictureUrl { get; set; }
    }
}
