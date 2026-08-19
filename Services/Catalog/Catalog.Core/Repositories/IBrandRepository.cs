using Catalog.Core.Entities;
using SharpCompress.Compressors.ZStandard.Unsafe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Core.Repositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<ProductBrand>> GetAllBrands();
        Task<ProductBrand> GetBrandByIdAsync(string id);
    }
}
