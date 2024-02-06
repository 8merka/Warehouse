using Microsoft.AspNetCore.Mvc;
using Moq;
using WarehouseAPI.Controllers;
using WarehouseBAL.Interfaces;
using WarehouseDAL.DTO;
using WarehouseDAL.Models;
using Xunit;

namespace Tests
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _mockProductService = new Mock<IProductService>();
            _controller = new ProductController(_mockProductService.Object);
        }

        [Fact]
        public void GetAllProductsOk()
        {
            // Arrange
            _mockProductService.Setup(service => service.GetAllProducts()).Returns(new List<Product>());

            // Act
            var result = _controller.GetAllProducts();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CreateProductOkWhenValid()
        {
            // Arrange
            var productDTO = new ProductDTO { DepartmentId = 1, Name = "Test", Manufacturer = "Test Manufacturer", WarrantyStartDate = DateTime.Now, WarrantyEndDate = DateTime.Now.AddYears(1) };

            // Act
            var result = _controller.Create(productDTO);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UpdateProductOkWhenValid()
        {
            // Arrange
            var productDTO = new ProductDTO { DepartmentId = 1, Name = "Test", Manufacturer = "Test Manufacturer", WarrantyStartDate = DateTime.Now, WarrantyEndDate = DateTime.Now.AddYears(1) };
            _mockProductService.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<Product>())).Returns(new Product());

            // Act
            var result = _controller.Update(1, productDTO);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeleteProductOkWhenExists()
        {
            // Arrange
            _mockProductService.Setup(service => service.Delete(It.IsAny<int>())).Returns(new Product());

            // Act
            var result = _controller.Delete(1);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
