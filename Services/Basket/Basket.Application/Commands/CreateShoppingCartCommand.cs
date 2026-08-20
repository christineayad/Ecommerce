using Basket.Application.DTOs;
using Basket.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Application.Commands
{
    public record CreateShoppingCartCommand(string UserName, List<CreateShoppingCartItemDto> Items) : IRequest<ShoppingCartResponse>;
}
