using Microsoft.AspNetCore.Mvc;
using Moq;
using WarehouseAPI.Controllers;
using WarehouseBAL.Interfaces;
using WarehouseDAL.DTO;
using WarehouseDAL.Models;
using Xunit;

namespace Tests
{
    public class DepartmentControllerTests
    {
        private readonly Mock<IDepartmentService> _mockDepartmentService;
        private readonly DepartmentController _controller;

        public DepartmentControllerTests()
        {
            _mockDepartmentService = new Mock<IDepartmentService>();
            _controller = new DepartmentController(_mockDepartmentService.Object);
        }

        [Fact]
        public void GetAllDepartmentsOk()
        {
            // Arrange
            _mockDepartmentService.Setup(service => service.GetAllDepartments()).Returns(new List<Department>());

            // Act
            var result = _controller.GetAllDepartments();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CreateDepartmentOkWhenValid()
        {
            // Arrange
            var departmentDTO = new DepartmentDTO { Name = "Test" };

            // Act
            var result = _controller.Create(departmentDTO);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UpdateDepartmentOkWhenValid()
        {
            // Arrange
            var departmentDTO = new DepartmentDTO { Name = "Test" };
            _mockDepartmentService.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<Department>())).Returns(new Department());

            // Act
            var result = _controller.Update(1, departmentDTO);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeleteDepartmentOkWhenExists()
        {
            // Arrange
            _mockDepartmentService.Setup(service => service.Delete(It.IsAny<int>())).Returns(new Department());

            // Act
            var result = _controller.Delete(1);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}


// Arrange

// Act

// Assert