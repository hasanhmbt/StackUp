using StackUp.Application.DTOs.Common;

namespace StackUp.Application.DTOs
{
    public class InventoryDTO : BaseDto
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int QuantityOnHand { get; set; }
        public int ReorderLevel { get; set; }
    }
}
