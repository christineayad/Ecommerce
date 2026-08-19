using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Handler
{
    public class GetProductByIdHandler : IRequestHandler<GetProuctByIdQuery, ProductResponse>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
      

        public async Task<ProductResponse> Handle(GetProuctByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProduct(request.id);
            return product.ToResponse();
        }
    }
}
