using Catalog.API.Entities;
using Catalog.API.IRepository;

namespace Catalog.API.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IMongoContext context) : base(context)
        {
        }
    }
}
