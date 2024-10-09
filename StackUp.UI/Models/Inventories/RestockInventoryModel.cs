using System.ComponentModel.DataAnnotations;

namespace StackUp.UI.Models.Inventories
{
    public class RestockInventoryModel
    {
        [Required(ErrorMessage = "Inventory ID is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Quantity to restock is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Restock quantity must be at least 1.")]
        public int Quantity { get; set; }
    }
}
