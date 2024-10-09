using System.ComponentModel.DataAnnotations;

namespace StackUp.UI.Models.OrderDetails
{
    public class DeleteOrderDetailsModel
    {
        [Required(ErrorMessage = "Order Details ID is required.")]
        public int Id { get; set; }
    }
}
