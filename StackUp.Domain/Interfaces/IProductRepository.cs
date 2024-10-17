using StackUp.Domain.Entities;

namespace StackUp.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        // Task<IEnumerable<object>> GetAllProductsAsync();
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
    }
}
