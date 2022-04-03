using AutoMapper;
using DotnetTemplateMsa.Domain.Categories;

namespace DotnetTemplateMsa.Api.Categories;

public class DomainToResourceProfile : Profile
{
    public DomainToResourceProfile()
    {
        CreateMap<Category, CategoryResource>();
    }
}