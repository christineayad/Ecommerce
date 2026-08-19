using Basket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Core.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string userName);
        Task<ShoppingCart> UpSertBasket(ShoppingCart basket);
        Task  DeleteBasket(string userName);
    }
}
