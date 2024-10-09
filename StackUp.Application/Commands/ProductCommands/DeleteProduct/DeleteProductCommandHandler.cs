using MediatR;
using StackUp.Application.Commands.ProductCommands;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.CommandHandlers.ProductHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with Id {request.Id} not found.");
            }

            _unitOfWork.Repository<Product>().Delete(product);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
