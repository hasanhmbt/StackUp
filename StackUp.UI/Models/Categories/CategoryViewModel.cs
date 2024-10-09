using StackUp.UI.Models.Products;

namespace StackUp.UI.Models.Categories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }

        public CategoryViewModel Parent { get; set; }
        public IReadOnlyCollection<CategoryViewModel> Children { get; set; }
        public IReadOnlyCollection<ProductViewModel> Products { get; set; }
    }


}
