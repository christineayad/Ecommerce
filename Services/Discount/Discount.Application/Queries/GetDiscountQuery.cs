using Discount.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Application.Queries
{
    public record GetDiscountQuery(string ProductName) : IRequest<CouponDto>;
   
}
