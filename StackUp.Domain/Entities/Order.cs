namespace StackUp.Domain.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public int OrderNumber { get; private set; }
        public int SupplierId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public int CustomerId { get; private set; }

        public Supplier Supplier { get; private set; }
        public Customer Customer { get; private set; }
        public ICollection<OrderDetails> OrderDetails { get; private set; } = new List<OrderDetails>();

        private Order() { }

        public Order(int orderNumber, int supplierId, DateTime orderDate, int customerId)
        {
            if (orderNumber <= 0)
                throw new ArgumentException("Order number must be positive.", nameof(orderNumber));
            if (orderDate == default)
                throw new ArgumentException("Order date must be valid.", nameof(orderDate));

            OrderNumber = orderNumber;
            SupplierId = supplierId;
            OrderDate = orderDate;
            CustomerId = customerId;
        }

        public void AddOrderDetails(OrderDetails details)
        {
            if (details == null)
                throw new ArgumentNullException(nameof(details));

            OrderDetails.Add(details);
        }

        public void RemoveOrderDetails(OrderDetails details)
        {
            if (details == null)
                throw new ArgumentNullException(nameof(details));

            OrderDetails.Remove(details);
        }

    }
}
