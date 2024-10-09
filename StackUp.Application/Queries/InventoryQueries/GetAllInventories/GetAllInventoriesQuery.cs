using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Queries.InventoryQueries
{
    public class GetAllInventoriesQuery : IRequest<List<InventoryDTO>>
    {
    }
}
