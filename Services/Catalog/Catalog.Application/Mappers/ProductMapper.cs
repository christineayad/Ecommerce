using Catalog.Application.Comands;
using Catalog.Application.DTOs;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Specification;


namespace Catalog.Application.Mappers
{
    public static class ProductMapper
    {
        public static ProductResponse ToResponse(this Product product)
        {
            if (product == null) return null;

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Summary = product.Summary,
                Description = product.Description,
                ImageFile = product.ImageFile,
                Price = product.Price,
                Brand = product.Brand,
                Type = product.Type,
                CreatedDate = product.CreatedDate
            };
        }

        public static Pagination<ProductResponse> ToResponse(
            this Pagination<Product> pagination)
            => new Pagination<ProductResponse>(
                pagination.PageIndex,
                pagination.PageSize,
                pagination.Count,
                pagination.Data.Select(p => p.ToResponse()).ToList()
            );
        public static List<ProductResponse> ToResponseList(this IEnumerable<Product> products)
        {
            if (products == null) return null;
            return products.Select(p => p.ToResponse()).ToList();
        }
        public static Product ToEntity(this CreateProductCommand command, ProductBrand brand, ProductType type)
        {
            if (command == null) return null;
            return new Product
            {
                Name = command.Name,
                Summary = command.Summary,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
                Brand = brand,
                Type = type,
                CreatedDate = DateTimeOffset.UtcNow
            };
        }
        public static Product ToUpdateEntity(this UpdateProductCommand command, Product existingProduct, ProductBrand brand, ProductType type)
        {
            if (command == null || existingProduct == null) return null;
            return new Product
            {
                Id = existingProduct.Id,
                Name = command.Name,
                Summary = command.Summary,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
                Brand = brand,
                Type = type,
                CreatedDate = existingProduct.CreatedDate
            };
        }
        public static ProductDto ToDto(this ProductResponse productResponse)
        {
            if (productResponse == null) return null;
            return new ProductDto
            (
               productResponse.Id,
               productResponse.Name,
               productResponse.Summary,
                productResponse.Description ,
               productResponse. ImageFile ,
               
              new BrandDto(productResponse.Brand.Id,productResponse.Brand.Name),
              new TypeDto (productResponse.Type.Id,productResponse.Type.Name),
             productResponse.Price,
               DateTimeOffset.UtcNow
            );
        }
        public static UpdateProductCommand ToCommand(this UpdateProductDto updateProductDto, string id)
        {
            if (updateProductDto == null) return null;
            return new UpdateProductCommand
            {
                Id = id,
                Name = updateProductDto.Name,
                Summary= updateProductDto.Summary,
                Description= updateProductDto.Description,
                ImageFile=  updateProductDto.ImageFile,
                Price=updateProductDto.Price,
              Brand=  updateProductDto.BrandId,
                Type=updateProductDto.TypeId
            };
        }
    }
}
