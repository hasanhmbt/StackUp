using System.ComponentModel.DataAnnotations;

namespace StackUp.UI.Models.Products
{
    public class DeleteProductModel
    {
        [Required(ErrorMessage = "Product ID is required.")]
        public int Id { get; set; }
    }
}
