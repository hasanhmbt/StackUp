using AutoMapper;
using StackUp.Domain.Entities;
using StackUp.UI.Models.Products;

namespace StackUp.UI.ModelMappingProfiles
{
    public class ProductModelMapping : Profile
    {
        public ProductModelMapping()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => src.Supplier))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

            CreateMap<CreateProductModel, Product>();
            CreateMap<EditProductModel, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
