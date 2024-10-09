using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Queries.OrderQueries
{
    public class GetAllOrdersQuery : IRequest<List<OrderDTO>>
    {
    }
}
