namespace StackUp.Application.DTOs
{
    public class OrderDetailsDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
