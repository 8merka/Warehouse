using Microsoft.AspNetCore.Mvc;
using Moq;
using WarehouseAPI.Controllers;
using WarehouseBAL.Interfaces;
using WarehouseDAL.DTO;
using WarehouseDAL.Models;
using Xunit;

namespace Tests
{
    public class WorkerDepartmentControllerTests
    {
        private readonly Mock<IWorkerDepartmentService> _mockWorkerDepartmentService;
        private readonly WorkerDepartmentController _controller;

        public WorkerDepartmentControllerTests()
        {
            _mockWorkerDepartmentService = new Mock<IWorkerDepartmentService>();
            _controller = new WorkerDepartmentController(_mockWorkerDepartmentService.Object);
        }

        [Fact]
        public void GetAllWorkerDepartmentsOk()
        {
            // Arrange
            _mockWorkerDepartmentService.Setup(service => service.GetAllWorkerDepartments()).Returns(new List<WorkerDepartment>());

            // Act
            var result = _controller.GetAllWorkerDepartments();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CreateWorkerDepartmentOkWhenValid()
        {
            // Arrange
            var workerDepartmentDTO = new WorkerDepartmentDTO { WorkerId = 1, DepartmentId = 1 };

            // Act
            var result = _controller.Create(workerDepartmentDTO);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UpdateWorkerDepartmentOkWhenValid()
        {
            // Arrange
            var workerDepartmentDTO = new WorkerDepartmentDTO { WorkerId = 1, DepartmentId = 1 };
            _mockWorkerDepartmentService.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<WorkerDepartment>())).Returns(new WorkerDepartment());

            // Act
            var result = _controller.Update(1, 1, workerDepartmentDTO);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeleteWorkerDepartmentOkWhenExists()
        {
            // Arrange
            _mockWorkerDepartmentService.Setup(service => service.Delete(It.IsAny<int>(), It.IsAny<int>())).Returns(new WorkerDepartment());

            // Act
            var result = _controller.Delete(1, 1);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}

