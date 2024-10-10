using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;
using StackUp.Infrastructure.Persistence;

namespace StackUp.Infrastructure.Repositories;

public class SupplierRepository : Repository<Supplier>, ISupplierRepository
{
    public SupplierRepository(InventoryDbContext context) : base(context) { }
}




