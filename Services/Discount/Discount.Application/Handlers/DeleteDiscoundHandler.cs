using Discount.Application.Commands;
using Discount.Application.Extensions;
using Discount.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Application.Handlers
{
    public class DeleteDiscoundHandler : IRequestHandler<DeleteDiscoundCommand, bool>
    {
        private readonly IDiscountRepository _discountRepository;
        public DeleteDiscoundHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
      
        public Task<bool> Handle(DeleteDiscoundCommand request, CancellationToken cancellationToken)
        {
            //validate The input
            if (string.IsNullOrWhiteSpace(request.ProductName))
            {
                //   throw new ArgumentException("ProductName is required.", nameof(request.ProductName));
                var validationErrors = new Dictionary<string, string>
                {
                    { nameof(request.ProductName), "ProductName is required." }
                };
                throw GrpcErrorHelper.CreateValidationException(validationErrors);
            }
            //delete the discount
            var deleted = _discountRepository.DeleteDiscount(request.ProductName);
            return deleted;

        }
    }
}
