namespace StackUp.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string ProductName { get; private set; }
        public int SupplierId { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public int CategoryId { get; private set; }

        public Supplier Supplier { get; private set; }
        public Category Category { get; private set; }
        public Inventory Inventory { get; private set; }

        private Product() { }

        public Product(string productName, int supplierId, decimal price, int quantity, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException("Product name cannot be empty.", nameof(productName));
            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero.", nameof(price));
            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));

            ProductName = productName;
            SupplierId = supplierId;
            Price = price;
            Quantity = quantity;
            CategoryId = categoryId;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("Price must be greater than zero.", nameof(newPrice));

            Price = newPrice;
        }

        public void AdjustQuantity(int amount)
        {
            if (Quantity + amount < 0)
                throw new InvalidOperationException("Insufficient quantity.");

            Quantity += amount;
        }

    }
}
