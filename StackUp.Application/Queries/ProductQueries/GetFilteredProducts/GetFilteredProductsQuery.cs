using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Queries.ProductQueries
{
    public class GetFilteredProductsQuery : IRequest<List<ProductDTO>>
    {
        public string ProductName { get; }
        public List<int> CategoryIds { get; }
        public List<int> SupplierIds { get; }

        public GetFilteredProductsQuery(string productName, List<int> categoryIds, List<int> supplierIds)
        {
            ProductName = productName;
            CategoryIds = categoryIds;
            SupplierIds = supplierIds;
        }
    }
}
