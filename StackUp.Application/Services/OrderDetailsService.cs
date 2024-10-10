using MediatR;
using StackUp.Application.Commands.OrderDetails;
using StackUp.Application.Commands.OrderDetailsCommands;
using StackUp.Application.DTOs;
using StackUp.Application.Queries.OrderDetailsQueries;

namespace StackUp.Application.Services
{
    public class OrderDetailsService
    {
        private readonly IMediator _mediator;

        public OrderDetailsService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<OrderDetailsDTO>> GetAllOrderDetailsAsync(int? orderId = null)
        {
            return await _mediator.Send(new GetAllOrderDetailsQuery(orderId));
        }

        public async Task<OrderDetailsDTO> GetOrderDetailsByIdAsync(int id)
        {
            return await _mediator.Send(new GetOrderDetailsByIdQuery(id));
        }

        public async Task AddOrderDetailsAsync(OrderDetailsDTO orderDetailsDto)
        {
            var command = new CreateOrderDetailsCommand(
                orderDetailsDto.ProductId,
                orderDetailsDto.Quantity,
                orderDetailsDto.OrderId
            );
            await _mediator.Send(command);
        }

        public async Task UpdateOrderDetailsAsync(OrderDetailsDTO orderDetailsDto)
        {
            var command = new UpdateOrderDetailsCommand(
                orderDetailsDto.Id,
                orderDetailsDto.ProductId,
                orderDetailsDto.Quantity
            );
            await _mediator.Send(command);
        }

        public async Task RemoveOrderDetailsAsync(int id)
        {
            var command = new DeleteOrderDetailsCommand(id);
            await _mediator.Send(command);
        }
    }
}
