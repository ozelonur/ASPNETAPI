using AutoMapper;
using KPSS.Core;
using KPSS.Core.DTOs;
using KPSS.Core.Repositories;
using KPSS.Core.Services;
using KPSS.Core.UnitOfWorks;

namespace KPSS.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, IMapper mapper,
            ICategoryRepository categoryRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            Category category = await _categoryRepository.GetSingleCategoryByIdWithProductsAsync(categoryId);

            CategoryWithProductsDto categoryDto = _mapper.Map<CategoryWithProductsDto>(category);

            return CustomResponseDto<CategoryWithProductsDto>.Success(200, categoryDto);
        }
    }
}