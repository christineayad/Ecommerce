using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using Catalog.Application.Mapper;


namespace Catalog.Application.Handler
{
    public class GetAllProductByBrandHandler : IRequestHandler<GetAllProductByBrand, IList<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        public GetAllProductByBrandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IList<ProductResponse>> Handle(GetAllProductByBrand request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetProductByBrand(request.BrandName);
            return productList.ToResponseList();

        }
    }
}
