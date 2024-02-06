using WarehouseDAL.Models;

namespace WarehouseBAL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        void Create(Product product);
        Product Update(int id, Product product);
        Product Delete(int id);
        Task<bool> ExistsAsync(int id);
    }
}
