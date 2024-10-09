using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Queries.CustomerQueries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<CustomerDTO>
    {
        public int Id { get; set; }

        public GetCustomerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
