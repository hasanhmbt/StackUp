using AutoMapper;
using StackUp.Domain.Entities;

public class OrderModelProfile : Profile
{
    public OrderModelProfile()
    {
        CreateMap<Order, StackUp.UI.Models.Orders.OrderViewModel>()
            .ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => src.Supplier))
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

        CreateMap<Supplier, StackUp.UI.Models.Suppliers.SupplierViewModel>();
        CreateMap<Customer, StackUp.UI.Models.Customers.CustomerViewModel>();
        CreateMap<OrderDetails, StackUp.UI.Models.OrderDetails.OrderDetailsViewModel>();

        CreateMap<StackUp.UI.Models.Orders.CreateOrderModel, Order>()
            .ForMember(dest => dest.OrderDetails, opt => opt.Ignore());

        CreateMap<StackUp.UI.Models.Orders.EditOrderModel, Order>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.OrderDetails, opt => opt.Ignore());

        CreateMap<StackUp.UI.Models.Orders.CreateOrderDetailsModel, OrderDetails>();
        CreateMap<StackUp.UI.Models.Orders.EditOrderDetailsModel, OrderDetails>();

        CreateMap<StackUp.UI.Models.OrderDetails.CreateOrderDetailsModel, OrderDetails>();
        CreateMap<StackUp.UI.Models.OrderDetails.EditOrderDetailsModel, OrderDetails>();
    }
}
