using AutoMapper;
using MediatR;
using StackUp.Application.Commands.OrderDetails;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.CommandHandlers.OrderDetailsHandlers
{
    public class CreateOrderDetailsCommandHandler : IRequestHandler<CreateOrderDetailsCommand, OrderDetailsDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderDetailsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDetailsDTO> Handle(CreateOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Repository<Order>().GetByIdAsync(request.OrderId);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with Id {request.OrderId} not found.");
            }

            var orderDetails = _mapper.Map<OrderDetails>(request);
            order.OrderDetails.Add(orderDetails);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<OrderDetailsDTO>(orderDetails);
        }
    }
}
