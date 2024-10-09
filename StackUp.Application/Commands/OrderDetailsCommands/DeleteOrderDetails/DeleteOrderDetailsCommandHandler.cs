using MediatR;
using StackUp.Application.Commands.OrderDetailsCommands;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.CommandHandlers.OrderDetailsHandlers
{
    public class DeleteOrderDetailsCommandHandler : IRequestHandler<DeleteOrderDetailsCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderDetailsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var orderDetails = await _unitOfWork.Repository<OrderDetails>().GetByIdAsync(request.Id);
            if (orderDetails == null)
            {
                throw new KeyNotFoundException($"Order details with Id {request.Id} not found.");
            }

            _unitOfWork.Repository<OrderDetails>().Delete(orderDetails);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
