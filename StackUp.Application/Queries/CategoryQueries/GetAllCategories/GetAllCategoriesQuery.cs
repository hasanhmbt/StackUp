using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Queries.CategoryQueries
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryDTO>>
    {
    }
}
