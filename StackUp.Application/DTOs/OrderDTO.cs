using StackUp.Application.DTOs.Common;

namespace StackUp.Application.DTOs
{
    public class OrderDTO : BaseDto
    {

        public int OrderNumber { get; set; }
        public int SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? CustomerName { get; set; }
        public List<OrderDetailsDTO> OrderDetails { get; set; } = new();
    }
}
