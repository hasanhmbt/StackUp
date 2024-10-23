using StackUp.Domain.Entities.Common;

namespace StackUp.Domain.Entities
{
    public class Product : Base
    {
        public string ProductName { get; private set; }
        public int SupplierId { get; private set; }
        public decimal SellingPrice { get; private set; }
        public decimal PurchasePrice { get; private set; }
        public int Quantity { get; private set; }
        public int CategoryId { get; private set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }

        public Supplier Supplier { get; private set; }
        public Category Category { get; private set; }
        public Inventory Inventory { get; private set; }

        private Product() { }

        public Product(string productName, int supplierId, decimal sellingPrice, decimal purchasePrice, int quantity, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException("Product name cannot be empty.", nameof(productName));
            if (sellingPrice <= 0)
                throw new ArgumentException("Selling price must be greater than zero.", nameof(sellingPrice));
            if (purchasePrice <= 0)
                throw new ArgumentException("Purchase price must be greater than zero.", nameof(purchasePrice));
            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));

            ProductName = productName;
            SupplierId = supplierId;
            SellingPrice = sellingPrice;
            PurchasePrice = purchasePrice;
            Quantity = quantity;
            CategoryId = categoryId;
        }

        public void UpdateSellingPrice(decimal newSellingPrice)
        {
            if (newSellingPrice <= 0)
                throw new ArgumentException("Selling price must be greater than zero.", nameof(newSellingPrice));

            SellingPrice = newSellingPrice;
        }

        public void UpdatePurchasePrice(decimal newPurchasePrice)
        {
            if (newPurchasePrice <= 0)
                throw new ArgumentException("Purchase price must be greater than zero.", nameof(newPurchasePrice));

            PurchasePrice = newPurchasePrice;
        }

        public void AdjustQuantity(int amount)
        {
            if (Quantity + amount < 0)
                throw new InvalidOperationException("Insufficient quantity.");

            Quantity += amount;
        }
    }
}
