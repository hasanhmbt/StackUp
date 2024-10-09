using MediatR;
using StackUp.Application.Commands.CustomerCommands;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.CommandHandlers.CustomerHandlers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(request.Id);
            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with Id {request.Id} not found.");
            }

            _unitOfWork.Repository<Customer>().Delete(customer);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
