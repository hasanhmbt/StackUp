using MediatR;
using StackUp.Application.Commands.SupplierCommands;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.CommandHandlers.SupplierHandlers
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSupplierCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _unitOfWork.Repository<Supplier>().GetByIdAsync(request.Id);
            if (supplier == null)
            {
                throw new KeyNotFoundException($"Supplier with Id {request.Id} not found.");
            }

            _unitOfWork.Repository<Supplier>().Delete(supplier);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
