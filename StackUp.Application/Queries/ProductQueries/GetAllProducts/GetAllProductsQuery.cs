using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Queries.ProductQueries
{
    public class GetAllProductsQuery : IRequest<List<ProductDTO>>
    {
    }
}
