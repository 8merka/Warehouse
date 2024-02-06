using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.Logging;
using WarehouseBAL.Interfaces;
using WarehouseDAL.Data;
using WarehouseDAL.Models;

namespace WarehouseBAL.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public ProductService(AppDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<Product> GetAllProducts() => _context.Products;
        public void Create(Product product)
        {
            try
            {
                _logger.LogInformation("Trying to create new line into Product table");
                _context.Products.Add(product);
                _context.SaveChanges();
                _logger.LogInformation($"Line {product.Id} {product.DepartmentId} {product.Name} {product.Manufacturer} {product.WarrantyStartDate} {product.WarrantyEndDate} succesfully added");
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, ex);
                throw;
            }
            finally
            {
                _logger.LogInformation("Creating new line into Product table ended");
            }
        }
        public Product Update(int id, Product product)
        {
            Product updatedProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (updatedProduct != null)
            {
                updatedProduct.DepartmentId = product.DepartmentId;
                updatedProduct.Name = product.Name;
                updatedProduct.Manufacturer = product.Manufacturer;
                updatedProduct.WarrantyStartDate = product.WarrantyStartDate;
                updatedProduct.WarrantyEndDate = product.WarrantyEndDate;

                _context.SaveChanges();
                return updatedProduct;
            }
            return null;
        }
        public Product Delete(int id)
        {
            Product deletedProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (deletedProduct != null)
            {
                _context.Products.Remove(deletedProduct);
                _context.SaveChanges();
                return deletedProduct;
            }
            return null;
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Products.AnyAsync(e => e.Id == id);
        }
    }
}
