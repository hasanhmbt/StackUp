using AutoMapper;
using StackUp.Application.Commands.OrderCommands;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;

namespace StackUp.Application.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.SupplierName))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.CustomerName))
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

            CreateMap<OrderDTO, Order>()
                .ConstructUsing((src, context) => new Order(
                    src.OrderNumber,
                    src.SupplierId,
                    src.OrderDate,
                    src.CustomerId))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Supplier, opt => opt.Ignore())
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.OrderDetails, opt => opt.Ignore());

            CreateMap<CreateOrderCommand, Order>()
                .ConstructUsing((src, context) => new Order(
                    src.OrderNumber,
                    src.SupplierId,
                    src.OrderDate,
                    src.CustomerId))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Supplier, opt => opt.Ignore())
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.OrderDetails, opt => opt.Ignore());

            CreateMap<UpdateOrderCommand, Order>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.OrderNumber))
                .ForMember(dest => dest.SupplierId, opt => opt.MapFrom(src => src.SupplierId))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.Supplier, opt => opt.Ignore())
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.OrderDetails, opt => opt.Ignore());
        }
    }
}
