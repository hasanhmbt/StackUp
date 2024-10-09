using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Queries.SupplierQueries
{
    public class GetAllSuppliersQuery : IRequest<List<SupplierDTO>>
    {
    }
}
