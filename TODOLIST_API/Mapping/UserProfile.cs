using AutoMapper;
using TODOLIST_API.DTO;
using TODOLIST_API.Models;

namespace TODOLIST_API.Mapping
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();

            CreateMap<User, UserLoginDto>().ReverseMap();

            CreateMap<User, UserLoginResponseDto>().ReverseMap();

        }
    }
}
