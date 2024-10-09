using System.ComponentModel.DataAnnotations;

namespace StackUp.UI.Models.Orders
{
    public class EditOrderModel
    {
        [Required(ErrorMessage = "Order ID is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Order number is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Order number must be positive.")]
        public int OrderNumber { get; set; }

        [Required(ErrorMessage = "Supplier ID is required.")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Order date is required.")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Customer ID is required.")]
        public int CustomerId { get; set; }

        public ICollection<EditOrderDetailsModel> OrderDetails { get; set; }
    }

    public class EditOrderDetailsModel
    {
        [Required(ErrorMessage = "Order Details ID is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product ID is required.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
    }
}
