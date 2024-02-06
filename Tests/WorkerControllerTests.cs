using Microsoft.AspNetCore.Mvc;
using Moq;
using WarehouseAPI.Controllers;
using WarehouseBAL.Interfaces;
using WarehouseDAL.DTO;
using WarehouseDAL.Models;
using Xunit;

namespace Tests
{
    public class WorkerControllerTests
    {
        private readonly Mock<IWorkerService> _mockWorkerService;
        private readonly WorkerController _controller;

        public WorkerControllerTests()
        {
            _mockWorkerService = new Mock<IWorkerService>();
            _controller = new WorkerController(_mockWorkerService.Object);
        }

        [Fact]
        public void GetAllWorkers_ReturnsOkResult()
        {
            // Arrange
            _mockWorkerService.Setup(service => service.GetAllWorkers()).Returns(new List<Worker>());

            // Act
            var result = _controller.GetAllWorkers();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void CreateWorkerOkWhenValid()
        {
            // Arrange
            var workerDTO = new WorkerDTO { FirstName = "Test", LastName = "Test", Age = 30 };

            // Act
            var result = _controller.Create(workerDTO);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UpdateWorkerOkWhenValid()
        {
            // Arrange
            var workerDTO = new WorkerDTO { FirstName = "Test", LastName = "Test", Age = 30 };
            _mockWorkerService.Setup(service => service.Update(It.IsAny<int>(), It.IsAny<Worker>())).Returns(new Worker());

            // Act
            var result = _controller.Update(1, workerDTO);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeleteWorkerOkWhenExists()
        {
            // Arrange
            _mockWorkerService.Setup(service => service.Delete(It.IsAny<int>())).Returns(new Worker());

            // Act
            var result = _controller.Delete(1);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }

}

