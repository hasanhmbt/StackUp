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
        public List<OrderDetailsDTO> OrderDetails { get; set; } = new List<OrderDetailsDTO>();

        public CreateOrderCommand(int orderNumber, int supplierId, DateTime orderDate, int customerId, List<OrderDetailsDTO> orderDetails)
        {
            OrderNumber = orderNumber;
            SupplierId = supplierId;
            OrderDate = orderDate;
            CustomerId = customerId;
            OrderDetails = orderDetails;
        }
    }
}
