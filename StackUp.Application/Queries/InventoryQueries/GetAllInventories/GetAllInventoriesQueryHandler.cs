using AutoMapper;
using MediatR;
using StackUp.Application.DTOs;
using StackUp.Application.Queries.InventoryQueries;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.QueryHandlers.InventoryHandlers
{
    public class GetAllInventoriesQueryHandler : IRequestHandler<GetAllInventoriesQuery, List<InventoryDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllInventoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<InventoryDTO>> Handle(GetAllInventoriesQuery request, CancellationToken cancellationToken)
        {
            var inventories = await _unitOfWork.Repository<Inventory>().GetAllAsync();
            return _mapper.Map<List<InventoryDTO>>(inventories);
        }
    }
}
