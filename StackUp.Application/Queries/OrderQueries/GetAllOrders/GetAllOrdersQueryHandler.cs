using AutoMapper;
using MediatR;
using StackUp.Application.DTOs;
using StackUp.Application.Queries.OrderQueries;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.QueryHandlers.OrderHandlers
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<OrderDTO>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.Repository<Order>().GetAllAsync();
            return _mapper.Map<List<OrderDTO>>(orders);
        }
    }
}



