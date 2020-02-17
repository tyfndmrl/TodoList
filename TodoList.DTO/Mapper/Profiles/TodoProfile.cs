using AutoMapper;
using TodoList.DAL.Entities;
using TodoList.DTO.Models.Todo;

namespace TodoList.DTO.Mapper.Profiles
{
    internal class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<Todo, TodoDto>().ReverseMap();
        }
    }
}
