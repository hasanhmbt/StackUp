using AutoMapper;
using StackUp.Domain.Entities;
using StackUp.UI.Models.Inventories;

public class InventoryMappingProfile : Profile
{
    public InventoryMappingProfile()
    {

        CreateMap<AdjustInventoryModel, Inventory>();
        CreateMap<RestockInventoryModel, Inventory>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());


    }
}
