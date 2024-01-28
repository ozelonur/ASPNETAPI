using KPSS.Core;
using KPSS.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KPSS.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<List<Product>> GetProductsWithCategoryAsync()
        {
            return await context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}

