using Catalog.Application.Comand;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Mapper
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
            existingProduct.Id = command.Id;
            existingProduct.Name = command.Name;
            existingProduct.Summary = command.Summary;
            existingProduct.Description = command.Description;
            existingProduct.ImageFile = command.ImageFile;
            existingProduct.Price = command.Price;
            existingProduct.Brand = brand;
            existingProduct.Type = type;
            return existingProduct;
        }
    }
}
