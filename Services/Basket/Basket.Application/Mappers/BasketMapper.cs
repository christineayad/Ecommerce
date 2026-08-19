using Basket.Application.Responses;
using Basket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Application.Mappers
{
    public static class BasketMapper
    {
    
     public static ShoppingCartResponse ToResponse(this ShoppingCart shoppingCart)
        {
            return new ShoppingCartResponse
            {
                UserName = shoppingCart.UserName,
                Items = shoppingCart.Items.Select(item => new ShoppingCartItemResponse
                {
                    Quantity = item.Quantity,
                    ImageFile = item.ImageFile,
                    Price = item.Price,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName
                }).ToList()
            };
        }
    }
}
