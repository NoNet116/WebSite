using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using WebSite.ViewModels.Account;

namespace WebSite.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ViewModel → DTO
            CreateMap<RegisterViewModel, RegisterUserDto>()
                 .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordReg));

            // DTO → User Entity
            CreateMap<RegisterUserDto, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailReg))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));

            CreateMap<LoginViewModel, LoginUserDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
