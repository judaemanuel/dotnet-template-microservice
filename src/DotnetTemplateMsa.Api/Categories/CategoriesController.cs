using AutoMapper;
using DotnetTemplateMsa.Domain.Categories;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTemplateMsa.Api.Categories;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoriesController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoryResource>> Get()
    {
        IEnumerable<Category> categories = await _categoryService.ListAsync();
        return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
    }
}