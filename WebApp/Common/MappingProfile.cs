using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;

namespace WebApp.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User
            CreateMap<UserRegisterDto, User>();
        }
    }
}
