using StackUp.UI.Models.Categories;
using StackUp.UI.Models.Suppliers;

namespace StackUp.UI.Models.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }

        public SupplierViewModel Supplier { get; set; }
        public CategoryViewModel Category { get; set; }

        public ICollection<ProductViewModel> RelatedProducts { get; set; }
    }


}
