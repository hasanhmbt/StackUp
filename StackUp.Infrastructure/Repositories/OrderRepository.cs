using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;
using StackUp.Infrastructure.Persistence;

namespace StackUp.Infrastructure.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(InventoryDbContext context) : base(context) { }
}




