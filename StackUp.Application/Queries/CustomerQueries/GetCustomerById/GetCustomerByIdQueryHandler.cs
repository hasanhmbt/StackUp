using AutoMapper;
using MediatR;
using StackUp.Application.DTOs;
using StackUp.Application.Queries.CustomerQueries.GetCustomerById;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.QueryHandlers.CustomerHandlers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(request.Id);
            if (customer == null)
            {
                return null;
            }

            return _mapper.Map<CustomerDTO>(customer);
        }
    }
}
