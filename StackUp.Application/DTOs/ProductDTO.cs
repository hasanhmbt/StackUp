using StackUp.Application.DTOs.Common;

namespace StackUp.Application.DTOs
{
    public class ProductDTO : BaseDto
    {

        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
