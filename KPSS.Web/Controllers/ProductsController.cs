using KPSS.Core;
using KPSS.Core.DTOs;
using KPSS.Web.Filters;
using KPSS.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KPSS.Web.Controllers;

public class ProductsController : Controller
{
    private readonly ProductApiService _productApiService;
    private readonly CategoryApiService _categoryApiService;

    public ProductsController(ProductApiService productApiService, CategoryApiService categoryApiService)
    {
        _productApiService = productApiService;
        _categoryApiService = categoryApiService;
    }


    // GET
    public async Task<IActionResult> Index()
    {
        return View(await _productApiService.GetProductsWithCategoryAsync());
    }

    public async Task<IActionResult> Save()
    {
        List<CategoryDto> categories = await _categoryApiService.GetAllAsync();

        ViewBag.categories = new SelectList(categories, "Id", "Name");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Save(ProductDto productDto)
    {
        if (ModelState.IsValid)
        {
            await _productApiService.SaveAsync(productDto);
            return RedirectToAction(nameof(Index));
        }

        IEnumerable<CategoryDto> categories = await _categoryApiService.GetAllAsync();

        ViewBag.categories = new SelectList(categories, "Id", "Name");

        return View();
    }

    [ServiceFilter(typeof(NotFoundFilter<Product>))]
    public async Task<IActionResult> Update(int id)
    {
        ProductDto product = await _productApiService.GetByIdAsync(id);
        IEnumerable<CategoryDto> categories = await _categoryApiService.GetAllAsync();

        ViewBag.categories = new SelectList(categories, "Id", "Name", product.CategoryId);

        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Update(ProductDto productDto)
    {
        if (ModelState.IsValid)
        {
            await _productApiService.UpdateAsync(productDto);
            return RedirectToAction(nameof(Index));
        }

        IEnumerable<CategoryDto> categories = await _categoryApiService.GetAllAsync();

        ViewBag.categories = new SelectList(categories, "Id", "Name", productDto.CategoryId);

        return View(productDto);
    }

    public async Task<IActionResult> Remove(int id)
    {
        await _productApiService.RemoveAsync(id);

        return RedirectToAction(nameof(Index));
    }
}