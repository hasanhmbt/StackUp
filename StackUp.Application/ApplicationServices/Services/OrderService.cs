﻿using MediatR;
using StackUp.Application.Commands.OrderCommands;
using StackUp.Application.DTOs;
using StackUp.Application.Queries.OrderQueries;
using StackUp.Application.Queries.OrderQueries.GetFilteredOrders;

namespace StackUp.Application.ApplicationServices.Services
{
    public class OrderService
    {
        private readonly IMediator _mediator;

        public OrderService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            return await _mediator.Send(new GetAllOrdersQuery());
        }

        public async Task<OrderDTO> GetOrderByIdAsync(int id)
        {
            return await _mediator.Send(new GetOrderByIdQuery(id));
        }

        public async Task AddOrderAsync(OrderDTO orderDto)
        {
            var command = new CreateOrderCommand(
                orderDto.OrderNumber,
                orderDto.SupplierId,
                orderDto.OrderDate,
                orderDto.CustomerId,
                orderDto.ProductId,
                orderDto.Quantity,
                orderDto.OrderDetails
            );
            await _mediator.Send(command);
        }

        public async Task UpdateOrderAsync(OrderDTO orderDto)
        {
            var command = new UpdateOrderCommand(
                orderDto.Id,
                orderDto.OrderNumber,
                orderDto.SupplierId,
                orderDto.OrderDate,
                orderDto.CustomerId,
              orderDto.ProductId,
                orderDto.Quantity,
                orderDto.OrderDetails
            );
            await _mediator.Send(command);
        }


        public async Task<IEnumerable<OrderDTO>> GetFilteredOrdersAsync(string orderNumber, List<int> supplierIds, List<int> customerIds)
        {
            return await _mediator.Send(new GetFilteredOrdersQuery(orderNumber, supplierIds, customerIds));
        }


        public async Task RemoveOrderAsync(int id)
        {
            var command = new DeleteOrderCommand(id);
            await _mediator.Send(command);
        }
    }
}
