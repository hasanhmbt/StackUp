using AutoMapper;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;
using StackUp.Domain.ValueObjects;

namespace StackUp.Application.MappingProfiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ContactInfo.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.ContactInfo.Phone));

            CreateMap<SupplierDTO, Supplier>()
                .ConstructUsing((src, context) => new Supplier(
                    src.SupplierName,
                    new ContactInfo(src.Email, src.Phone)))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ContactInfo, opt => opt.Ignore())
                .ForMember(dest => dest.Products, opt => opt.Ignore());
        }
    }
}
