using System.ComponentModel.DataAnnotations;

namespace StackUp.UI.Models.Products
{
    public class EditProductModel
    {
        [Required(ErrorMessage = "Product ID is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Product name must not exceed 100 characters.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Supplier ID is required.")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryId { get; set; }
    }
}
