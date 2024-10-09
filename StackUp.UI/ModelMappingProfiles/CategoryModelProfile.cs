using AutoMapper;
using StackUp.Domain.Entities;
using StackUp.UI.Models.Categories;

namespace StackUp.UI.ModelMappingProfiles
{
    public class CategoryModelProfile : Profile
    {
        public CategoryModelProfile()
        {
            CreateMap<Category, CategoryViewModel>()
                .ForMember(dest => dest.Parent, opt => opt.MapFrom(src => src.Parent))
                .ForMember(dest => dest.Children, opt => opt.MapFrom(src => src.Children))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products)).ReverseMap();

            CreateMap<CreateCategoryModel, Category>()
                .ConstructUsing(src => new Category(src.CategoryName, src.Description, src.ParentId));

            CreateMap<EditCategoryModel, Category>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.ParentId))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Parent, opt => opt.Ignore())
                .ForMember(dest => dest.Children, opt => opt.Ignore())
                .ForMember(dest => dest.Products, opt => opt.Ignore());

            CreateMap<DeleteCategoryModel, Category>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
