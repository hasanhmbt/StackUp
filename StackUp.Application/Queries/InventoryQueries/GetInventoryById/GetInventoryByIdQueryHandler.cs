using AutoMapper;
using MediatR;
using StackUp.Application.DTOs;
using StackUp.Application.Queries.InventoryQueries;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.QueryHandlers.InventoryHandlers
{
    public class GetInventoryByIdQueryHandler : IRequestHandler<GetInventoryByIdQuery, InventoryDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetInventoryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<InventoryDTO> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
        {
            var inventory = await _unitOfWork.Repository<Inventory>().GetByIdAsync(request.Id);
            if (inventory == null)
            {
                return null;
            }

            return _mapper.Map<InventoryDTO>(inventory);
        }
    }
}
