using AutoMapper;
using StackUp.Application.Commands.CategoryCommands;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;

namespace StackUp.Application.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent != null ? src.Parent.CategoryName : null))
                .ForMember(dest => dest.Children, opt => opt.MapFrom(src => src.Children));

            CreateMap<CategoryDTO, Category>()
                .ConstructUsing((src, context) => new Category(
                    src.CategoryName,
                    src.Description,
                    src.ParentId))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Parent, opt => opt.Ignore())
                .ForMember(dest => dest.Children, opt => opt.Ignore())
                .ForMember(dest => dest.Products, opt => opt.Ignore());

            CreateMap<CreateCategoryCommand, Category>()
                .ConstructUsing((src, context) => new Category(
                    src.CategoryName,
                    src.Description,
                    src.ParentId))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Parent, opt => opt.Ignore())
                .ForMember(dest => dest.Children, opt => opt.Ignore())
                .ForMember(dest => dest.Products, opt => opt.Ignore());

            CreateMap<UpdateCategoryCommand, Category>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.ParentId))
                .ForMember(dest => dest.Parent, opt => opt.Ignore())
                .ForMember(dest => dest.Children, opt => opt.Ignore())
                .ForMember(dest => dest.Products, opt => opt.Ignore());
        }
    }
}
