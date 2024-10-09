using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery : IRequest<CategoryDTO>
    {
        public int Id { get; set; }

        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
