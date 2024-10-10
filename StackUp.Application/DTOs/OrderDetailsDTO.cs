using StackUp.Application.DTOs.Common;

namespace StackUp.Application.DTOs
{
    public class OrderDetailsDTO : BaseDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
