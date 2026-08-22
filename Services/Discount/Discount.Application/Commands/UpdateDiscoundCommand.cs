using Discount.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Application.Commands
{
    public record UpdateDiscoundCommand(int Id,string ProductName, string Description, int Amount) : IRequest<CouponDto>;
   
}
