using MediatR;
using StackUp.Application.Commands.SupplierCommands;
using StackUp.Application.DTOs;
using StackUp.Application.Queries.SupplierQueries;

namespace StackUp.Application.ApplicationServices.Services
{
    public class SupplierService
    {
        private readonly IMediator _mediator;

        public SupplierService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<SupplierDTO>> GetAllSuppliersAsync()
        {
            return await _mediator.Send(new GetAllSuppliersQuery());
        }

        public async Task<SupplierDTO> GetSupplierByIdAsync(int id)
        {
            return await _mediator.Send(new GetSupplierByIdQuery(id));
        }

        public async Task AddSupplierAsync(SupplierDTO supplierDto)
        {
            var command = new CreateSupplierCommand(
                supplierDto.SupplierName,
                supplierDto.Email,
                supplierDto.Phone
            );
            await _mediator.Send(command);
        }

        public async Task UpdateSupplierAsync(SupplierDTO supplierDto)
        {
            var command = new UpdateSupplierCommand(
                supplierDto.Id,
                supplierDto.SupplierName,
                supplierDto.Email,
                supplierDto.Phone
            );
            await _mediator.Send(command);
        }

        public async Task RemoveSupplierAsync(int id)
        {
            var command = new DeleteSupplierCommand(id);
            await _mediator.Send(command);
        }
    }
}
