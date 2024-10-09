using AutoMapper;
using MediatR;
using StackUp.Application.Commands.OrderDetails;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.CommandHandlers.OrderDetailsHandlers
{
    public class UpdateOrderDetailsCommandHandler : IRequestHandler<UpdateOrderDetailsCommand, OrderDetailsDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOrderDetailsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDetailsDTO> Handle(UpdateOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var orderDetails = await _unitOfWork.Repository<OrderDetails>().GetByIdAsync(request.Id);
            if (orderDetails == null)
            {
                throw new KeyNotFoundException($"Order details with Id {request.Id} not found.");
            }

            _mapper.Map(request, orderDetails);
            _unitOfWork.Repository<OrderDetails>().Update(orderDetails);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<OrderDetailsDTO>(orderDetails);
        }
    }
}
