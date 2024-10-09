// SupplierModelMapping.cs
using AutoMapper;
using StackUp.Domain.Entities;
using StackUp.Domain.ValueObjects;
using StackUp.UI.Models.Products;
using StackUp.UI.Models.Suppliers;

namespace StackUp.UI.ModelMappingProfiles
{
    public class SupplierModelMapping : Profile
    {
        public SupplierModelMapping()
        {
            CreateMap<Supplier, SupplierViewModel>()
                .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            CreateMap<ContactInfoModel, ContactInfo>();
            CreateMap<ContactInfo, ContactInfoViewModel>();
            CreateMap<Product, ProductViewModel>();

            CreateMap<CreateSupplierModel, Supplier>()
                .ForMember(dest => dest.Products, opt => opt.Ignore());

            CreateMap<EditSupplierModel, Supplier>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Products, opt => opt.Ignore());
        }
    }
}
