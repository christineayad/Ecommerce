
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace Catalog.Infrastructure
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IMongoCollection<ProductBrand> _brands;
        //public BrandRepository(IConfiguration config)
        //{
        //    var client = new MongoClient(config["DatabaseSettings:ConnectionString"]);
        //    var db = client.GetDatabase(config["DatabaseSettings:DatabaseName"]);
        //    _brands = db.GetCollection<ProductBrand>(config["DatabaseSettings:BrandCollectionName"]);
        //}
        public BrandRepository(IOptions<DatabaseSettings> options)
        {
            var settings = options.Value;
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);
            _brands = db.GetCollection<ProductBrand>(settings.BrandCollectionName);
        }
        public async Task<IEnumerable<ProductBrand>> GetAllBrands()
        {
            return await _brands.Find(brand => true).ToListAsync();
        }

        public Task<ProductBrand> GetBrandByIdAsync(string id)
        {
            return _brands.Find(brand => brand.Id == id).FirstOrDefaultAsync();
        }
    }
}
