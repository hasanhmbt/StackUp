using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;
using StackUp.Infrastructure.Persistence;

namespace StackUp.Infrastructure.Repositories;

public class InventoryRepository : Repository<Inventory>, IInventoryRepository
{
    public InventoryRepository(InventoryDbContext context) : base(context) { }

}




