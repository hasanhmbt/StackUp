using StackUp.Domain.Entities.Common;
using StackUp.Domain.ValueObjects;

namespace StackUp.Domain.Entities
{
    public class Supplier : Base
    {
        public string SupplierName { get; private set; }
        public ContactInfo ContactInfo { get; private set; }

        private readonly List<Product> _products = new();
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        private Supplier() { }

        public Supplier(string supplierName, ContactInfo contactInfo)
        {
            if (string.IsNullOrWhiteSpace(supplierName))
                throw new ArgumentException("Supplier name cannot be empty.", nameof(supplierName));

            SupplierName = supplierName;
            ContactInfo = contactInfo ?? throw new ArgumentNullException(nameof(contactInfo));
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (_products.Exists(p => p.Id == product.Id))
                throw new InvalidOperationException("Product already exists for this supplier.");

            _products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            _products.Remove(product);
        }

    }
}
