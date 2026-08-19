using Catalog.Application.Comands;
using Catalog.Application.Mappers;
using Catalog.Core.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Handler
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
           var productexisting=await _productRepository.GetProduct(request.Id);
            if (productexisting == null)
            {
                throw new KeyNotFoundException($"Product with id {request.Id} not found.");
            }
            //fetch brand and type from repository
            var brand = await _productRepository.GetBrandByIdAsync(request.Brand);
            var type = await _productRepository.GetTypeByIdAsync(request.Type);
            if (brand == null || type == null)
            {
                throw new ApplicationException("Invalid brand or type");
            }
            var updateproduct = request.ToUpdateEntity(productexisting,brand,type);
            //save to repository && return response

            return await _productRepository.UpdateProduct(updateproduct);
        }
    }
}
