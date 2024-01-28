using AutoMapper;
using KPSS.Core;
using KPSS.Core.DTOs;
using KPSS.Core.Services;
using KPSS.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KPSS.Web.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _services;
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public ProductsController(IProductService services, ICategoryService categoryService, IMapper mapper)
    {
        _services = services;
        _categoryService = categoryService;
        _mapper = mapper;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        return View(await _services.GetProductsWithCategory());
    }

    public async Task<IActionResult> Save()
    {
        IEnumerable<Category> categories = await _categoryService.GetAllAsync();

        List<CategoryDto> categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());

        ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Save(ProductDto productDto)
    {
        if (ModelState.IsValid)
        {
            await _services.AddAsync(_mapper.Map<Product>(productDto));
            return RedirectToAction(nameof(Index));
        }

        IEnumerable<Category> categories = await _categoryService.GetAllAsync();

        List<CategoryDto> categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());

        ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");

        return View();
    }

    [ServiceFilter(typeof(NotFoundFilter<Product>))]
    public async Task<IActionResult> Update(int id)
    {
        Product product = await _services.GetByIdAsync(id);
        IEnumerable<Category> categories = await _categoryService.GetAllAsync();

        List<CategoryDto> categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());

        ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", product.CategoryId);

        return View(_mapper.Map<ProductDto>(product));
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(ProductDto productDto)
    {
        if (ModelState.IsValid)
        {
            await _services.UpdateAsync(_mapper.Map<Product>(productDto));
            return RedirectToAction(nameof(Index));
        }
        
        IEnumerable<Category> categories = await _categoryService.GetAllAsync();

        List<CategoryDto> categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());

        ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", productDto.CategoryId);

        return View(productDto);
    }

    public async Task<IActionResult> Remove(int id)
    {
        Product product = await _services.GetByIdAsync(id);

        await _services.RemoveAsync(product);

        return RedirectToAction(nameof(Index));

    }
}