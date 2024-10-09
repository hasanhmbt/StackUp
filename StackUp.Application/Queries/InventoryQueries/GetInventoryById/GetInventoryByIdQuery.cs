using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Queries.InventoryQueries
{
    public class GetInventoryByIdQuery : IRequest<InventoryDTO>
    {
        public int Id { get; set; }

        public GetInventoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
