using AutoMapper;
using Data.Dtos;
using Data.Models;

namespace Data.Mappers.MyAutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, UserDto>();
            CreateMap<UserDto, UserModel>();
        }
    }
}
