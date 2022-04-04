using AutoMapper;
using DotnetTemplateMsa.Domain.TodoLists;

namespace DotnetTemplateMsa.Api.TodoLists
{
    public class TodoListMapperProfile : Profile
    {
        public TodoListMapperProfile()
        {
            CreateMap<TodoList, TodoListResource>();
        }
    }
}