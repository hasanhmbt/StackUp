using AutoMapper;
using StackUp.Application.Commands.InventoryCommands;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;

namespace StackUp.Application.MappingProfiles
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<Inventory, InventoryDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.ProductName : string.Empty))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product != null ? src.Product.Id : 0));

            CreateMap<InventoryDTO, Inventory>()
                .ConstructUsing((src, context) => new Inventory(
                    src.ProductId,
                    src.QuantityOnHand,
                    src.ReorderLevel))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore());

            CreateMap<CreateInventoryCommand, Inventory>()
                .ConstructUsing((src, context) => new Inventory(
                    src.ProductId,
                    src.QuantityOnHand,
                    src.ReorderLevel))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore());

            CreateMap<UpdateInventoryCommand, Inventory>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.QuantityOnHand, opt => opt.MapFrom(src => src.QuantityOnHand))
                .ForMember(dest => dest.ReorderLevel, opt => opt.MapFrom(src => src.ReorderLevel))
                .ForMember(dest => dest.Product, opt => opt.Ignore());
        }
    }
}
