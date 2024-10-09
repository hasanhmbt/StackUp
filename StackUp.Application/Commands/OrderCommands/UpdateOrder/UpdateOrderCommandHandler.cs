using AutoMapper;
using MediatR;
using StackUp.Application.Commands.OrderCommands;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.CommandHandlers.OrderHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDTO> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Repository<Order>().GetByIdAsync(request.Id);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with Id {request.Id} not found.");
            }

            _mapper.Map(request, order);
            _unitOfWork.Repository<Order>().Update(order);
            await _unitOfWork.CommitAsync();

            var updatedOrder = await _unitOfWork.Repository<Order>().GetByIdAsync(order.Id);
            return _mapper.Map<OrderDTO>(updatedOrder);
        }
    }
}
