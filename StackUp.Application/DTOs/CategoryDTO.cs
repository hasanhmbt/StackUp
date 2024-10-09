using StackUp.Application.DTOs.Common;

namespace StackUp.Application.DTOs
{
    public class CategoryDTO : BaseDto
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public string ParentName { get; set; }
        public List<CategoryDTO> Children { get; set; } = new();
    }
}
