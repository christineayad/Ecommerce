using Discount.Application.Commands;
using Discount.Application.DTOs;
using Discount.Application.Extensions;
using Discount.Application.Mappers;
using Discount.Core.Repositories;
using Grpc.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Application.Handlers
{
    public class UpdateDiscoundHandler:IRequestHandler<UpdateDiscoundCommand,CouponDto>
    {
        private readonly IDiscountRepository _discountRepository;
        public UpdateDiscoundHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
        public async Task<CouponDto> Handle(UpdateDiscoundCommand request, CancellationToken cancellationToken)
        {
            //validate input
            var validationErrors = new Dictionary<string, string>();
            if (string.IsNullOrWhiteSpace(request.ProductName))
                validationErrors["ProductName"] = "Product name must not be empty.";
            if (string.IsNullOrWhiteSpace(request.Description))
                validationErrors["Description"] = "Product Description must not be empty.";
            if (request.Amount <= 0)
                validationErrors["Amount"] = "Amount must be greater than zero.";
            if (validationErrors.Any())
                throw GrpcErrorHelper.CreateValidationException(validationErrors);

            //Convert to Entity
            var coupon = request.ToEntity();
            //save to database
            var updatedDb = await _discountRepository.UpdateDiscount(coupon);

            if (!updatedDb)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Could not Update discount for product: {request.ProductName}"));
            }
            //Return DTO
            return coupon.ToDto();
        }
    }
}
