using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Queries.ProductQueries
{
    public class GetProductByIdQuery : IRequest<ProductDTO>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
