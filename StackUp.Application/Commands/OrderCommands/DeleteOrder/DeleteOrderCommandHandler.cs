using MediatR;
using StackUp.Application.Commands.OrderCommands;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.CommandHandlers.OrderHandlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Repository<Order>().GetByIdAsync(request.Id);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with Id {request.Id} not found.");
            }

            _unitOfWork.Repository<Order>().Delete(order);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
