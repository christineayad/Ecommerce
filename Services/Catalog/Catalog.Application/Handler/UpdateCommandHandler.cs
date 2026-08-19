using Catalog.Application.Comand;
using Catalog.Application.Mapper;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Handler
{
    public class UpdateCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public UpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = _productRepository.GetProduct(request.Id);
            if (existingProduct != null)
            {
                throw new KeyNotFoundException($"Product with Id {request.Id} not found.");

            }
            //fetch brand from repository
            var brand = await _productRepository.GetBrandByIdAsync(request.BrandId);

            //fetch type from repository
            var type = await _productRepository.GetTypeByIdAsync(request.TypeId);
            if (brand == null || type == null)
            {
                throw new ApplicationException($"Invalid brand or type specified");
            }
            //match to product entity
            var proproductentity = request.ToUpdateEntity(existingProduct, brand, type);
            var newproduct = await _productRepository.CreateProduct(proproductentity);
            return newproduct.ToResponse();
        }
    }
}
