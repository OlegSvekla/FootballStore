using FootballStore.Core.Interfaces;
using FootballStore.Core.Interfaces.Services;
using FootballStore.Core.Models;
using FootballStore.Infrastructure;
using FootballStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NuGet.Repositories;

namespace FootballStore.Controllers
{
    public class CatalogController : Controller
    {

           
        //fgdfgd
        private readonly ICatalogItemViewModelService _catalogItemViewModelService;
        private readonly IRepository<CatalogItem> _catalogRepository;

        public CatalogController(ICatalogItemViewModelService catalogItemViewModelService,
            IRepository<CatalogItem> catalogRepository)
        {
            _catalogItemViewModelService = catalogItemViewModelService;
            _catalogRepository = catalogRepository;
        }


        public async Task<IActionResult> Index(int? brandFilterAplied, int? typesFilterAplied)
        {
            var viewModel = await _catalogItemViewModelService.GetCatalogItems(brandFilterAplied, typesFilterAplied);

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var item = _catalogRepository.GetById(id);

            if (item == null) return RedirectToAction("Index");


            var result = new CatalogItemViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                PictureUrl = item.PictureUrl
            };
            return View(result);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _catalogRepository.GetById(id);

            if (item == null) return RedirectToAction("Index");


            var result = new CatalogItemViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                PictureUrl = item.PictureUrl
            };
            return View(result);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CatalogItemViewModel catalogItemViewModel)
        {
            try
            {
                _catalogItemViewModelService.UpdaitCatalogItem(catalogItemViewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View();
            }
        }

    }
}
