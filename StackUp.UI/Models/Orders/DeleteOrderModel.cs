using System.ComponentModel.DataAnnotations;

namespace StackUp.UI.Models.Orders
{
    public class DeleteOrderModel
    {
        [Required(ErrorMessage = "Order ID is required.")]
        public int Id { get; set; }
    }
}
