using AutoMapper;
using StackUp.Application.Commands.OrderDetails;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;

namespace StackUp.Application.MappingProfiles
{
    public class OrderDetailsProfile : Profile
    {
        public OrderDetailsProfile()
        {
            CreateMap<OrderDetails, OrderDetailsDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.ProductName : string.Empty))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product != null ? src.Product.Id : 0));

            CreateMap<OrderDetailsDTO, OrderDetails>()
                .ConstructUsing((src, context) => new OrderDetails(
                    src.ProductId,
                    src.Quantity))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.OrderId, opt => opt.Ignore())
                .ForMember(dest => dest.Order, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore());

            CreateMap<CreateOrderDetailsCommand, OrderDetails>()
                .ConstructUsing((src, context) => new OrderDetails(
                    src.ProductId,
                    src.Quantity))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.Order, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore());

            CreateMap<UpdateOrderDetailsCommand, OrderDetails>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.OrderId, opt => opt.Ignore())
                .ForMember(dest => dest.Order, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore());
        }
    }
}
