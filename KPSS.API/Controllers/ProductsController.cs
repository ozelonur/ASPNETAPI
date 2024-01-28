using AutoMapper;
using KPSS.API.Filters;
using KPSS.Core;
using KPSS.Core.DTOs;
using KPSS.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KPSS.API.Controllers
{
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;
        
        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _service = productService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _service.GetProductsWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<Product> products = await _service.GetAllAsync();

            List<ProductDto> productDtos = _mapper.Map<List<ProductDto>>(products.ToList());

            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
        }
        
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Product product = await _service.GetByIdAsync(id);

            ProductDto productDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto dto)
        {
            Product product = await _service.AddAsync(_mapper.Map<Product>(dto));
            ProductDto productDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productDto));
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto dto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(dto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            Product product = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(product);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}

