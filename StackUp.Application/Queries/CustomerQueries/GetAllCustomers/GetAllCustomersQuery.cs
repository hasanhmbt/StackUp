using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Queries.CustomerQueries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<List<CustomerDTO>>
    {
    }
}
