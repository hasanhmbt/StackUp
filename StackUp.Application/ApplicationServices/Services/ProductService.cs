using MediatR;
using StackUp.Application.Commands.ProductCommands;
using StackUp.Application.DTOs;
using StackUp.Application.Queries.ProductQueries;

namespace StackUp.Application.ApplicationServices.Services
{
    public class ProductService
    {
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            return await _mediator.Send(new GetAllProductsQuery());
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            return await _mediator.Send(new GetProductByIdQuery(id));
        }

        public async Task AddProductAsync(ProductDTO productDto)
        {
            var command = new CreateProductCommand(
                productDto.ProductName,
                productDto.SupplierId,
                productDto.SellingPrice,
                productDto.PurchasePrice,
                productDto.Quantity,
                productDto.CategoryId,
                productDto.Description,
                productDto.ImageUrl
            );
            await _mediator.Send(command);
        }

        public async Task UpdateProductAsync(ProductDTO productDto)
        {
            var command = new UpdateProductCommand(
                productDto.Id,
                productDto.ProductName,
                productDto.SupplierId,
                productDto.SellingPrice,
                productDto.PurchasePrice,
                productDto.Quantity,
                productDto.CategoryId,
                productDto.Description,
                productDto.ImageUrl
            );
            await _mediator.Send(command);
        }

        public async Task DeleteProductAsync(int id)
        {
            var command = new DeleteProductCommand(id);
            await _mediator.Send(command);
        }

        public async Task<IEnumerable<ProductDTO>> GetFilteredProductsAsync(string productName, List<int> categoryIds, List<int> supplierIds)
        {
            var query = new GetFilteredProductsQuery(productName, categoryIds, supplierIds);
            return await _mediator.Send(query);
        }
    }
}
