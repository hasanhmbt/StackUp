using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Commands.OrderCommands
{
    public class UpdateOrderCommand : IRequest<OrderDTO>
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int SupplierId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public List<OrderDetailsDTO> OrderDetails { get; set; } = new List<OrderDetailsDTO>();

        public UpdateOrderCommand(int id, int orderNumber, int supplierId, DateTime orderDate, int customerId, List<OrderDetailsDTO> orderDetails)
        {
            Id = id;
            OrderNumber = orderNumber;
            SupplierId = supplierId;
            OrderDate = orderDate;
            CustomerId = customerId;
            OrderDetails = orderDetails;
        }
    }
}
