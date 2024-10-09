using System.ComponentModel.DataAnnotations;

namespace StackUp.UI.Models.Categories
{
    public class DeleteCategoryModel
    {
        [Required(ErrorMessage = "Category ID is required.")]
        public int Id { get; set; }
    }
}
