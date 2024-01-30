using KPSS.API.Filters;
using KPSS.Core;
using KPSS.Core.DTOs;
using KPSS.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KPSS.API.Controllers
{
    public class ProductsWithDtoController : CustomBaseController
    {
        private readonly IProductServiceWithDto _productServiceWithDto;

        public ProductsWithDtoController(IProductServiceWithDto productServiceWithDto)
        {
            _productServiceWithDto = productServiceWithDto;
        }
        
        
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _productServiceWithDto.GetProductsWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return CreateActionResult(await _productServiceWithDto.GetAllAsync());
        }
        
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _productServiceWithDto.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductCreateDto dto)
        {
            return CreateActionResult(await _productServiceWithDto.AddAsync(dto));
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto dto)
        {
            return CreateActionResult(await _productServiceWithDto.UpdateAsync(dto));
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _productServiceWithDto.RemoveAsync(id));
        }

        [HttpPost("SaveAll")]
        public async Task<IActionResult> SaveAll(List<ProductDto> productDtos)
        {
            return CreateActionResult(await _productServiceWithDto.AddRangeAsync(productDtos));
        }
        
        [HttpDelete("RemoveAll")]
        public async Task<IActionResult> RemoveAll(List<int> ids)
        {
            return CreateActionResult(await _productServiceWithDto.RemoveRangeAsync(ids));
        }

        [HttpGet("Any/{id}")]
        public async Task<IActionResult> Any(int id)
        {
            return CreateActionResult(await _productServiceWithDto.AnyAsync(x => x.Id == id));
        }
    }
}

