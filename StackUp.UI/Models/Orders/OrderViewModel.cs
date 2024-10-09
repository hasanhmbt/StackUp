using StackUp.UI.Models.Customers;
using StackUp.UI.Models.OrderDetails;
using StackUp.UI.Models.Suppliers;

namespace StackUp.UI.Models.Orders
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int SupplierId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }

        public SupplierViewModel Supplier { get; set; }
        public CustomerViewModel Customer { get; set; }
        public ICollection<OrderDetailsViewModel> OrderDetails { get; set; }
    }
}
