using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Queries.OrderDetailsQueries
{
    public class GetAllOrderDetailsQuery : IRequest<List<OrderDetailsDTO>>
    {
        public int? OrderId { get; set; }

        public GetAllOrderDetailsQuery(int? orderId = null)
        {
            OrderId = orderId;
        }
    }
}
