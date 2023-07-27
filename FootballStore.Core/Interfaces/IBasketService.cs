﻿using FootballStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Core.Interfaces
{
    public interface IBasketService
    {
        Task<Basket> AddItem2Basket(string username, int catalogItemId, decimal price, int quantity = 1);
        Task<Basket> RemoveItemFromBasket(string username, int catalogItemId);
        Task<Basket> UpdateBasket(string username, Dictionary<int, int> itemQuantityPairs);
    }
}