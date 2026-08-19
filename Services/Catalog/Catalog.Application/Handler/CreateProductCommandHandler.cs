using Catalog.Application.Comand;
using Catalog.Application.Mapper;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Handler
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //fetch brand from repository
            var brand = await _productRepository.GetBrandByIdAsync(request.BrandId);

            //fetch type from repository
            var type = await _productRepository.GetTypeByIdAsync(request.TypeId);
            if (brand == null || type == null)
            {
                throw new ApplicationException($"Invalid brand or type specified");
            }
            //match to product entity
            var proproductentity = request.ToEntity(brand, type);
            var newproduct = await _productRepository.CreateProduct(proproductentity);
            return newproduct.ToResponse();

        }
    }
}
