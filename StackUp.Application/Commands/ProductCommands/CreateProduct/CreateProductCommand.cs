using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Commands.ProductCommands
{
    public class CreateProductCommand : IRequest<ProductDTO>
    {
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }

        public CreateProductCommand(string productName, int supplierId, decimal price, int quantity, int categoryId)
        {
            ProductName = productName;
            SupplierId = supplierId;
            Price = price;
            Quantity = quantity;
            CategoryId = categoryId;
        }
    }
}
