using Discount.Application.DTOs;
using Discount.Application.Extensions;
using Discount.Application.Mappers;
using Discount.Application.Queries;
using Discount.Core.Repositories;
using Grpc.Core;
using MediatR;
using Microsoft.IdentityModel.Tokens.Experimental;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;



namespace Discount.Application.Handlers
{
    public class GetDiscountHandler : IRequestHandler<GetDiscountQuery, CouponDto>
    {
        private readonly IDiscountRepository _discountRepository;
        public GetDiscountHandler(IDiscountRepository discountRepository)
        {
                _discountRepository = discountRepository;
        }
        public async Task<CouponDto> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
        {
            //validate The input
            if (string.IsNullOrWhiteSpace(request.ProductName))
            {
                //   throw new ArgumentException("ProductName is required.", nameof(request.ProductName));
                var validationErrors=new Dictionary<string, string>
                {
                    { nameof(request.ProductName), "ProductName is required." }
                };  
                throw GrpcErrorHelper.CreateValidationException(validationErrors);
            }
            // Fetch the repository to get the coupon
            var coupon = await _discountRepository.GetDiscount(request.ProductName);
            if(coupon == null)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Could not create discount for product: {request.ProductName}"));
            }
            //Mapping the coupon to CouponDto
            return coupon.ToDto();


        }
    }
}
