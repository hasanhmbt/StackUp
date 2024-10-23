using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Commands.OrderCommands
{
    public class CreateOrderCommand : IRequest<OrderDTO>
    {
        public int OrderNumber { get; set; }
        public int SupplierId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public List<OrderDetailsDTO> OrderDetails { get; set; } = new List<OrderDetailsDTO>();

        public CreateOrderCommand(int orderNumber, int supplierId, DateTime orderDate, int customerId, int productId, int quantity, List<OrderDetailsDTO> orderDetails)
        {
            OrderNumber = orderNumber;
            SupplierId = supplierId;
            OrderDate = orderDate;
            CustomerId = customerId;
            OrderDetails = orderDetails;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
