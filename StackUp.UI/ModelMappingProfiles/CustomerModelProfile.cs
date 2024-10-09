using AutoMapper;
using StackUp.Domain.Entities;
using StackUp.Domain.ValueObjects;
using StackUp.UI.Models.Customers;
using StackUp.UI.Models.Orders;

public class CustomerModelProfile : Profile
{
    public CustomerModelProfile()
    {
        CreateMap<Customer, CustomerViewModel>()
            .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo))
            .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders));

        CreateMap<ContactInfo, ContactInfoViewModel>();

        CreateMap<Order, OrderViewModel>();

        CreateMap<CreateCustomerModel, Customer>()
            .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo));

        CreateMap<EditCustomerModel, Customer>()
            .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

    }
}
