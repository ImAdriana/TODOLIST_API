using AutoMapper;
using TODOLIST_API.DTO;
using TODOLIST_API.Models;

namespace TODOLIST_API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoItem, TodoDto>();
            CreateMap<TodoInsertDto, TodoItem>();
            CreateMap<TodoUpdateDto, TodoItem>();
        }
    }
}
