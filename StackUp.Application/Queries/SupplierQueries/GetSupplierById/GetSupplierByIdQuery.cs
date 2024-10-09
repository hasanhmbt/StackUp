using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Queries.SupplierQueries
{
    public class GetSupplierByIdQuery : IRequest<SupplierDTO>
    {
        public int Id { get; set; }

        public GetSupplierByIdQuery(int id)
        {
            Id = id;
        }
    }
}
