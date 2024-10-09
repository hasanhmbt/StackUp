// File: StackUp.Application/CommandHandlers/OrderHandlers/CreateOrderCommandHandler.cs
using AutoMapper;
using MediatR;
using StackUp.Application.Commands.OrderCommands;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.CommandHandlers.OrderHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDTO> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);

            await _unitOfWork.Repository<Order>().AddAsync(order);
            await _unitOfWork.CommitAsync();

            var createdOrder = await _unitOfWork.Repository<Order>().GetByIdAsync(order.Id);
            return _mapper.Map<OrderDTO>(createdOrder);
        }
    }
}
