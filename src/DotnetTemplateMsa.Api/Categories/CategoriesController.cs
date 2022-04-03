using DotnetTemplateMsa.Domain.Categories;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTemplateMsa.Api.Categories;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IEnumerable<Category>> Get()
    {
        return await _categoryService.ListAsync();
    }
}