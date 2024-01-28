using KPSS.Core;
using KPSS.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KPSS.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            return await context.Categories.Include(x => x.Products).Where(x => x.Id == categoryId)
                .SingleOrDefaultAsync();    
        }
    }
}