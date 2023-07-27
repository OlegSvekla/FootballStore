using Microsoft.AspNetCore.Mvc.Rendering;

namespace FootballStore.ViewModels
{
    public sealed class CatalogIndexViewModel
    {
        public List<CatalogItemViewModel>? CatalogItems { get; set; }
        public List<SelectListItem>? Brands { get; set; }
        public List<SelectListItem>? Types { get; set; }

        public int? BrandFilterAplied { get; set; }
        public int? TypesFilterAplied { get; set; }
    }
}
