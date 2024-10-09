using AutoMapper;
using MediatR;
using StackUp.Application.DTOs;
using StackUp.Application.Queries.SupplierQueries;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.QueryHandlers.SupplierHandlers
{
    public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, SupplierDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSupplierByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SupplierDTO> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var supplier = await _unitOfWork.Repository<Supplier>().GetByIdAsync(request.Id);
            if (supplier == null)
            {
                return null;
            }

            return _mapper.Map<SupplierDTO>(supplier);
        }
    }
}
