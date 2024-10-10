using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;
using StackUp.Infrastructure.Persistence;

namespace StackUp.Infrastructure.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(InventoryDbContext context) : base(context) { }

}
 


 
