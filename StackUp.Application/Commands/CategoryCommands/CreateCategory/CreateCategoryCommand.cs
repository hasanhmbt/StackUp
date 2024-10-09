using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest<CategoryDTO>
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
    }
}
