using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;
using StackUp.Infrastructure.Persistence;

namespace StackUp.Infrastructure.Repositories;

public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
{
    public OrderDetailsRepository(InventoryDbContext context) : base(context) { }
}
 


