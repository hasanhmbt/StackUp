// StackUp.Domain/Entities/Customer.cs
using StackUp.Domain.ValueObjects;

namespace StackUp.Domain.Entities
{
    public class Customer
    {
        public int Id { get; private set; }
        public string CustomerName { get; private set; }
        public string Address { get; private set; }
        public ContactInfo ContactInfo { get; private set; }

        private readonly List<Order> _orders = new();
        public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

        private Customer() { }

        public Customer(string customerName, string address, ContactInfo contactInfo)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException("Customer name cannot be empty.", nameof(customerName));
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Address cannot be empty.", nameof(address));

            CustomerName = customerName;
            Address = address;
            ContactInfo = contactInfo ?? throw new ArgumentNullException(nameof(contactInfo));
        }

        public void AddOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            if (_orders.Exists(o => o.Id == order.Id))
                throw new InvalidOperationException("Order already exists for this customer.");

            _orders.Add(order);
        }

        public void RemoveOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            _orders.Remove(order);
        }

    }
}
