using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using WebSite.ViewModels;
using WebSite.ViewModels.Account;

namespace WebSite.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ViewModel → DTO
            CreateMap<RegisterViewModel, RegisterUserDTO>()
                 .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordReg));

            // DTO → User Entity
            CreateMap<RegisterUserDTO, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailReg))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));

            CreateMap<LoginViewModel, LoginUserDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            Article();



        }

        void Article()
        {
            // ArticleViewModel => ArticleDTO
            CreateMap<ArticleViewModel, ArticleDTO>()
                // DTO требует Id, CreatedAt, AuthorName и CommentCount, которых нет во ViewModel, можно игнорировать или задать по умолчанию
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Author, opt => opt.Ignore())
                .ForMember(dest => dest.CommentCount, opt => opt.Ignore())
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags));

            CreateMap<ArticleDTO, ArticleViewModel>()
                .ForMember(dest => dest.AuthorFullName, opt => opt.MapFrom(src => src.Author.FullName))
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(src => src.CreatedAt));
        }
    }
}
