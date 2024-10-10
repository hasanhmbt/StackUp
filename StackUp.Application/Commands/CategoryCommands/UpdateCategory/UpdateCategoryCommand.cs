using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Commands.CategoryCommands
{
    public class UpdateCategoryCommand : IRequest<CategoryDTO>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }

        public UpdateCategoryCommand(int id, string categoryName, string description, int? parentId)
        {
            Id = id;
            CategoryName = categoryName;
            Description = description;
            ParentId = parentId;
        }
    }
}