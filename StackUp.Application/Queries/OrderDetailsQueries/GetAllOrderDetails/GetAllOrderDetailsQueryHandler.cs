using AutoMapper;
using MediatR;
using StackUp.Application.DTOs;
using StackUp.Application.Queries.OrderDetailsQueries;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.QueryHandlers.OrderDetailsHandlers
{
    public class GetAllOrderDetailsQueryHandler : IRequestHandler<GetAllOrderDetailsQuery, List<OrderDetailsDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllOrderDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<OrderDetailsDTO>> Handle(GetAllOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<OrderDetails> orderDetails;

            if (request.OrderId.HasValue)
            {
                // Filter order details by OrderId
                orderDetails = await _unitOfWork.Repository<OrderDetails>()
                                    .FindAsync(od => od.OrderId == request.OrderId.Value);
            }
            else
            {
                orderDetails = await _unitOfWork.Repository<OrderDetails>().GetAllAsync();
            }

            return _mapper.Map<List<OrderDetailsDTO>>(orderDetails.ToList());
        }
    }
}
