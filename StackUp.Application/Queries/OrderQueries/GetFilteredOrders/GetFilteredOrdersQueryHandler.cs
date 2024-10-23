using AutoMapper;
using MediatR;
using StackUp.Application.DTOs;
using StackUp.Application.Queries.OrderQueries.GetFilteredOrders;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.QueryHandlers.OrderHandlers
{
    public class GetFilteredOrdersQueryHandler : IRequestHandler<GetFilteredOrdersQuery, List<OrderDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFilteredOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<OrderDTO>> Handle(GetFilteredOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.Repository<Order>().GetAllAsync();

            if (!string.IsNullOrWhiteSpace(request.OrderNumber))
            {
                orders = orders.Where(o => o.OrderNumber.ToString().Contains(request.OrderNumber));
            }

            if (request.SupplierIds != null && request.SupplierIds.Any())
            {
                orders = orders.Where(o => request.SupplierIds.Contains(o.SupplierId));
            }

            if (request.CustomerIds != null && request.CustomerIds.Any())
            {
                orders = orders.Where(o => request.CustomerIds.Contains(o.CustomerId));
            }

            var filteredOrders = orders.ToList();

            return _mapper.Map<List<OrderDTO>>(filteredOrders);
        }
    }
}
