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
        private readonly IBasketService _basketService;

        public CatalogController(ICatalogItemViewModelService catalogItemViewModelService,
            IRepository<CatalogItem> catalogRepository,
            IBasketService basketService)
        {
            _catalogItemViewModelService = catalogItemViewModelService;
            _catalogRepository = catalogRepository;
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? brandFilterAplied, int? typesFilterAplied)
        {
            var userName = GetOrSetBasketCookieAndUserName();

            var viewModel = await _catalogItemViewModelService.GetCatalogItems(brandFilterAplied, typesFilterAplied);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int id, decimal price)
        {
            var userName = GetOrSetBasketCookieAndUserName();
            var basket = await _basketService.AddItem2Basket(userName, id, price);

            return RedirectToAction("Index");
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

        private string GetOrSetBasketCookieAndUserName()
        {
            string? userName = default;

            if (this.HttpContext.User.Identity.IsAuthenticated)
            {
                return this.Request.HttpContext.User.Identity.Name;
            }

            if (this.Request.Cookies.ContainsKey("fShop")) 
            {
                userName = Request.Cookies["fShop"];

                if (!Request.HttpContext.User.Identity.IsAuthenticated) 
                {
                    userName = default;
                }
            }

            if (userName != null) return userName;

            userName = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Append("fShop", userName, cookieOptions);
            return userName;
        }


    }
}
