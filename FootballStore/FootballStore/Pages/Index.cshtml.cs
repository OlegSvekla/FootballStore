using FootballStore.Core.Interfaces.Services;
using FootballStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;

namespace FootballStore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogItemViewModelService _catalogViewModelService;

        public IndexModel(ICatalogItemViewModelService catalogViewModelServ)
        {
            _catalogViewModelService = catalogViewModelServ;
        }

        public CatalogIndexViewModel CatalogModel { get; set; } = new CatalogIndexViewModel();

        public async Task OnGet(CatalogIndexViewModel catalogModel, int? pageId)
        {
            CatalogModel = await _catalogViewModelService.GetCatalogItems(pageId ?? 0, Constants.ITEMS_PER_PAGE, catalogModel.BrandFilterAplied, catalogModel.TypesFilterAplied);

        }
    }
}
