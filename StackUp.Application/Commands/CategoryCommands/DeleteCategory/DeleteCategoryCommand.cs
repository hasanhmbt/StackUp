using MediatR;

namespace StackUp.Application.Commands.CategoryCommands
{
    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
