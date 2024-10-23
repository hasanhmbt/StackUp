using AutoMapper;
using MediatR;
using StackUp.Application.DTOs;
using StackUp.Application.Queries.ProductQueries;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.QueryHandlers.ProductHandlers
{
    public class GetFilteredProductsQueryHandler : IRequestHandler<GetFilteredProductsQuery, List<ProductDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFilteredProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> Handle(GetFilteredProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.Repository<Product>().GetAllAsync();

            if (!string.IsNullOrWhiteSpace(request.ProductName))
            {
                products = products.Where(p => p.ProductName.Contains(request.ProductName, System.StringComparison.OrdinalIgnoreCase));
            }

            if (request.CategoryIds != null && request.CategoryIds.Any())
            {
                products = products.Where(p => request.CategoryIds.Contains(p.CategoryId));
            }

            if (request.SupplierIds != null && request.SupplierIds.Any())
            {
                products = products.Where(p => request.SupplierIds.Contains(p.SupplierId));
            }

            var filteredProducts = products.ToList();

            return _mapper.Map<List<ProductDTO>>(filteredProducts);
        }
    }
}
