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
            //fetch brand and type from repository
            var brand = await _productRepository.GetBrandByIdAsync(request.Brand);
            var type = await _productRepository.GetTypeByIdAsync(request.Type);
            if (brand == null || type == null)
            {
                throw new ApplicationException("Invalid brand or type");
            }

            //Match entity 
            var productentity = request.ToEntity(brand, type);
            //save to repository
            var product = await _productRepository.CreateProduct(productentity);
            //return response
            return product.ToResponse();
        }

        }
    }
