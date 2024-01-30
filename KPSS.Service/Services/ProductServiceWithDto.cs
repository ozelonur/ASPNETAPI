using AutoMapper;
using KPSS.Core;
using KPSS.Core.DTOs;
using KPSS.Core.Repositories;
using KPSS.Core.Services;
using KPSS.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;

namespace KPSS.Service.Services
{
    public class ProductServiceWithDto : ServiceWithDto<Product, ProductDto>, IProductServiceWithDto
    {
        private IProductRepository _repository;

        public ProductServiceWithDto(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper,
            IProductRepository repository1) :
            base(repository, unitOfWork, mapper)
        {
            _repository = repository1;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            List<Product> products = await _repository.GetProductsWithCategoryAsync();
            List<ProductWithCategoryDto> productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(StatusCodes.Status200OK, productsDto);
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(ProductUpdateDto dto)
        {
            Product entity = _mapper.Map<Product>(dto);
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<CustomResponseDto<ProductDto>> AddAsync(ProductCreateDto dto)
        {
            Product newEntity = _mapper.Map<Product>(dto);
            await _repository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            ProductDto newDto = _mapper.Map<ProductDto>(newEntity);
            return CustomResponseDto<ProductDto>.Success(StatusCodes.Status200OK, newDto);
        }
    }
}