using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;

namespace WebApp.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, UserDetailDto>();
            CreateMap<UserDetailDto, User>();
            CreateMap<UserDetailDto, UserRegisterDto>();
        }
    }
}
