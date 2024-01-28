using AutoMapper;
using KPSS.Core;
using KPSS.Core.DTOs;
using KPSS.Core.Repositories;
using KPSS.Core.Services;
using KPSS.Core.UnitOfWorks;

namespace KPSS.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork,
            IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            List<Product> products = await _productRepository.GetProductsWithCategoryAsync();

            List<ProductWithCategoryDto> productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);

            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);  
        }
    }
}