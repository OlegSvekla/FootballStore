using FootballStore.Core.Interfaces;
using FootballStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Core.Servicess
{
    public class BasketService : IBasketService
    {
        private readonly IRepository<Basket> _basketRepository;

        public BasketService(IRepository<Basket> basketrepository)
        {
            _basketRepository = basketrepository;
        }

        public async Task<Basket> AddItem2Basket(string username, int catalogItemId, decimal price, int quantity = 1)
        {
            var basket = await _basketRepository.FirstOrDefaultAsync(b => b.BuyerId == username);
            if (basket == null) 
            {
                basket = new Basket(username);
                basket = await _basketRepository.AddAsync(basket);
            }

            basket.AddItem(catalogItemId, price, quantity);
            _basketRepository.UpdateAsync(basket);

            return basket;
        }
    }
}
