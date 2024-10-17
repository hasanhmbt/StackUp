using MediatR;
using StackUp.Application.Commands.CustomerCommands;
using StackUp.Application.DTOs;
using StackUp.Application.Queries.CustomerQueries.GetAllCustomers;
using StackUp.Application.Queries.CustomerQueries.GetCustomerById;

namespace StackUp.Application.ApplicationServices.Services
{
    public class CustomerService
    {
        private readonly IMediator _mediator;

        public CustomerService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync()
        {
            return await _mediator.Send(new GetAllCustomersQuery());
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
        {
            return await _mediator.Send(new GetCustomerByIdQuery(id));
        }

        public async Task AddCustomerAsync(CustomerDTO customerDto)
        {
            var command = new CreateCustomerCommand(
                customerDto.CustomerName,
                customerDto.Address,
                customerDto.Email,
                customerDto.Phone
            );
            await _mediator.Send(command);
        }

        public async Task UpdateCustomerAsync(CustomerDTO customerDto)
        {
            var command = new UpdateCustomerCommand(
                customerDto.Id,
                customerDto.CustomerName,
                customerDto.Address,
                customerDto.Email,
                customerDto.Phone
            );
            await _mediator.Send(command);
        }

        public async Task RemoveCustomerAsync(int id)
        {
            var command = new DeleteCustomerCommand(id);
            await _mediator.Send(command);
        }
    }
}
