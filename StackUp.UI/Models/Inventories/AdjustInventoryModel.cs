using System.ComponentModel.DataAnnotations;

namespace StackUp.UI.Models.Inventories
{
    public class AdjustInventoryModel
    {
        [Required(ErrorMessage = "Inventory ID is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Adjustment amount is required.")]
        public int AdjustmentAmount { get; set; } // Positive for addition, negative for subtraction

        [StringLength(250, ErrorMessage = "Reason for adjustment must not exceed 250 characters.")]
        public string Reason { get; set; } // Optional: reason for adjustment
    }
}
