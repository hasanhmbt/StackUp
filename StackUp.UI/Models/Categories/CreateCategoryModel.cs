using System.ComponentModel.DataAnnotations;

namespace StackUp.UI.Models.Categories
{
    public class CreateCategoryModel
    {
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100, ErrorMessage = "Category name must not exceed 100 characters.")]
        public string CategoryName { get; set; }

        [StringLength(500, ErrorMessage = "Description must not exceed 500 characters.")]
        public string Description { get; set; }

        public int? ParentId { get; set; }
    }
}
