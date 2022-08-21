using AutoMapper;
using Data.Dtos;
using Data.Models;

namespace Data.Mappers.MyAutoMapper
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<ToDoModel, ToDoDto>();
            CreateMap<ToDoDto, ToDoModel>();
        }
    }
}
