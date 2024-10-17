using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Commands.ProductCommands
{
    public class UpdateProductCommand : IRequest<ProductDTO>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public UpdateProductCommand(
            int id,
            string productName,
            int supplierId,
            decimal sellingPrice,
            decimal purchasePrice,
            int quantity,
            int categoryId,
            string description,
            string imageUrl)
        {
            Id = id;
            ProductName = productName;
            SupplierId = supplierId;
            SellingPrice = sellingPrice;
            PurchasePrice = purchasePrice;
            Quantity = quantity;
            CategoryId = categoryId;
            Description = description;
            ImageUrl = imageUrl;
        }
    }
}
