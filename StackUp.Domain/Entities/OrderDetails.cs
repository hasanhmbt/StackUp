using StackUp.Domain.Entities.Common;

namespace StackUp.Domain.Entities
{
    public class OrderDetails : Base
    {

        public int OrderId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }

        public Order Order { get; private set; }
        public Product Product { get; private set; }

        private OrderDetails() { }

        public OrderDetails(int productId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

            ProductId = productId;
            Quantity = quantity;
        }



    }
}
