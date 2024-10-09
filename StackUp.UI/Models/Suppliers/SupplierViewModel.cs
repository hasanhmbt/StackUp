using StackUp.UI.Models.Products;

namespace StackUp.UI.Models.Suppliers
{
    public class SupplierViewModel
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public ContactInfoViewModel ContactInfo { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }
    }

    public class ContactInfoViewModel
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
