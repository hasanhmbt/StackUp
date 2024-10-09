using AutoMapper;
using MediatR;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.Commands.CustomerCommands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(request.Id);
            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with Id {request.Id} not found.");
            }

            _mapper.Map(request, customer);
            _unitOfWork.Repository<Customer>().Update(customer);
            await _unitOfWork.CommitAsync();

            var updatedCustomer = await _unitOfWork.Repository<Customer>().GetByIdAsync(customer.Id);
            return _mapper.Map<CustomerDTO>(updatedCustomer);
        }
    }
}
