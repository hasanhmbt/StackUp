using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Queries.OrderQueries
{
    public class GetOrderByIdQuery : IRequest<OrderDTO>
    {
        public int Id { get; set; }

        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
