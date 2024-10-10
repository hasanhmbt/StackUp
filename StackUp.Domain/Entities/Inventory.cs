namespace StackUp.Domain.Entities
{
    public class Inventory
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int QuantityOnHand { get; set; }
        public int ReorderLevel { get; set; }

        public Product Product { get; private set; }

        private Inventory() { }

        public Inventory(int productId, int quantityOnHand, int reorderLevel)
        {
            if (quantityOnHand < 0)
                throw new ArgumentException("Quantity on hand cannot be negative.", nameof(quantityOnHand));
            if (reorderLevel < 0)
                throw new ArgumentException("Reorder level cannot be negative.", nameof(reorderLevel));

            ProductId = productId;
            QuantityOnHand = quantityOnHand;
            ReorderLevel = reorderLevel;
        }

        public void AdjustQuantity(int amount)
        {
            if (QuantityOnHand + amount < 0)
                throw new InvalidOperationException("Insufficient inventory.");

            QuantityOnHand += amount;
        }

        public bool NeedsReorder()
        {
            return QuantityOnHand <= ReorderLevel;
        }

    }
}
