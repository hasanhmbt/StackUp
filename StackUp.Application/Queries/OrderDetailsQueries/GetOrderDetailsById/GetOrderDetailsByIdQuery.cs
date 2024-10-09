using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Queries.OrderDetailsQueries
{
    public class GetOrderDetailsByIdQuery : IRequest<OrderDetailsDTO>
    {
        public int Id { get; set; }

        public GetOrderDetailsByIdQuery(int id)
        {
            Id = id;
        }
    }
}
