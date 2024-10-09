using AutoMapper;
using MediatR;
using StackUp.Application.Commands.CustomerCommands;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.CommandHandlers.CustomerHandlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);
            await _unitOfWork.Repository<Customer>().AddAsync(customer);
            await _unitOfWork.CommitAsync();

            var createdCustomer = await _unitOfWork.Repository<Customer>().GetByIdAsync(customer.Id);
            return _mapper.Map<CustomerDTO>(createdCustomer);
        }
    }
}
