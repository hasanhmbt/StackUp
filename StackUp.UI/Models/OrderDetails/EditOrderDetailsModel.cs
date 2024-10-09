using System.ComponentModel.DataAnnotations;

namespace StackUp.UI.Models.OrderDetails
{
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
