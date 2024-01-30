using KPSS.Core;
using KPSS.Core.DTOs;
using KPSS.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KPSS.API.Controllers
{
    public class CategoriesWithDtoController : CustomBaseController
    {
        private readonly IServiceWithDto<Category, CategoryDto> _service;

        public CategoriesWithDtoController(IServiceWithDto<Category, CategoryDto> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CreateActionResult(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto category)
        {
            return CreateActionResult(await _service.AddAsync(category));
        }
    }
}