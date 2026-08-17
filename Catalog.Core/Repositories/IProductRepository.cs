using Catalog.Core.Entities;
using Catalog.Core.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Core.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Pagination<Product>> GetProducts(CatalogSpecParams catalogSpecParams);
        Task<IEnumerable<Product>> GetProductByName(string Name);
        Task<IEnumerable<Product>> GetProductByBrand(string Name);
        Task<Product> GetProduct(string productId);
        Task<Product> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string productId);
        Task<ProductBrand>GetBrandByIdAsync(string brandId);
        Task<ProductType> GetTypeByIdAsync(string TyoeId);



    }
}
