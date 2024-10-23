using MediatR;
using StackUp.Application.DTOs;


namespace StackUp.Application.Queries.OrderQueries.GetFilteredOrders
{
    public class GetFilteredOrdersQuery : IRequest<List<OrderDTO>>
    {
        public string OrderNumber { get; }
        public List<int> SupplierIds { get; }
        public List<int> CustomerIds { get; }

        public GetFilteredOrdersQuery(string orderNumber, List<int> supplierIds, List<int> customerIds)
        {
            OrderNumber = orderNumber;
            SupplierIds = supplierIds;
            CustomerIds = customerIds;
        }
    }
}
