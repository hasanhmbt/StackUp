using AutoMapper;
using StackUp.Application.Commands.CustomerCommands;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;
using StackUp.Domain.ValueObjects;

namespace StackUp.Application.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ContactInfo.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.ContactInfo.Phone));

            CreateMap<CustomerDTO, Customer>()
                .ConstructUsing((src, context) => new Customer(
                    src.CustomerName,
                    src.Address,
                    new ContactInfo(src.Email, src.Phone)))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ContactInfo, opt => opt.Ignore())
                .ForMember(dest => dest.Orders, opt => opt.Ignore());

            CreateMap<CreateCustomerCommand, Customer>()
                .ConstructUsing((src, context) => new Customer(
                    src.CustomerName,
                    src.Address,
                    new ContactInfo(src.Email, src.Phone)))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpdateCustomerCommand, Customer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => new ContactInfo(src.Email, src.Phone)));
        }
    }
}
