namespace StackUp.Application.DTOs
{
    public class InventoryDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int QuantityOnHand { get; set; }
        public int ReorderLevel { get; set; }
    }
}
