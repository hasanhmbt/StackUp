using StackUp.UI.Models.Products;

namespace StackUp.UI.Models.OrderDetails
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public ProductViewModel Product { get; set; }
    }
}
