using AutoMapper;
using MediatR;
using StackUp.Application.DTOs;
using StackUp.Application.Queries.OrderDetailsQueries;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.QueryHandlers.OrderDetailsHandlers
{
    public class GetOrderDetailsByIdQueryHandler : IRequestHandler<GetOrderDetailsByIdQuery, OrderDetailsDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOrderDetailsByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDetailsDTO> Handle(GetOrderDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var orderDetails = await _unitOfWork.Repository<OrderDetails>().GetByIdAsync(request.Id);
            if (orderDetails == null)
            {
                return null;
            }

            return _mapper.Map<OrderDetailsDTO>(orderDetails);
        }
    }
}
