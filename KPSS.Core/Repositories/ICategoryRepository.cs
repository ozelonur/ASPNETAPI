namespace KPSS.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Task<Category> GetSingleCategoryByIdWithProductsAsync(int categoryId);
    }
}

