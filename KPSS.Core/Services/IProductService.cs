using KPSS.Core.DTOs;

namespace KPSS.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory();
    }
}

