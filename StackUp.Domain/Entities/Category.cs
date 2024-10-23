using StackUp.Domain.Entities.Common;

namespace StackUp.Domain.Entities
{
    public class Category : Base
    {
        public string CategoryName { get; private set; }
        public string Description { get; private set; }
        public int? ParentId { get; private set; }

        public Category Parent { get; private set; }
        private readonly List<Category> _children = new();
        public IReadOnlyCollection<Category> Children => _children.AsReadOnly();
        private readonly List<Product> _products = new();
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        private Category() { }

        public Category(string categoryName, string description, int? parentId = null)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                throw new ArgumentException("Category name cannot be empty.", nameof(categoryName));

            CategoryName = categoryName;
            Description = description;
            ParentId = parentId;
        }

        public void AddChild(Category child)
        {
            if (child == null)
                throw new ArgumentNullException(nameof(child));

            if (_children.Exists(c => c.Id == child.Id))
                throw new InvalidOperationException("Child category already exists.");

            _children.Add(child);
        }

        public void RemoveChild(Category child)
        {
            if (child == null)
                throw new ArgumentNullException(nameof(child));

            _children.Remove(child);
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (_products.Exists(p => p.Id == product.Id))
                throw new InvalidOperationException("Product already exists in this category.");

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
