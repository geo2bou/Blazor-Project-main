using BlazorApp.Client.Models;
using BlazorApp.Client.Services;
using BlazorApp.Controllers;
using BlazorApp.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BlazorApp.UnitTests.Controllers
{
    public class CustomersControllerTests
    {
        private readonly Mock<CustomerService> _mockService;
        private readonly CustomersController _controller;
        private readonly ApplicationDbContext _context;

        public CustomersControllerTests()
        {
            _mockService = new Mock<CustomerService>();
            _controller = new CustomersController(_context, null);
        }

        [Fact]
        public async Task CreateCustomerInvalidModel()
        {
            // Arrange
            _controller.ModelState.AddModelError("CompanyName", "Required");
            var model = new Models.Customer();

            // Act
            var result = await _controller.CreateCustomer(model);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }


        [Fact]
        public async Task UpdateCustomerWithException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var updateDto = new Customer { Id = id, CompanyName = "Test" };
            _mockService.Setup(s => s.UpdateCustomer(updateDto)).ThrowsAsync(new Exception("fail"));

            // Act
            var result = await _controller.UpdateCustomer(id, updateDto);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Contains("fail", badRequest?.Value?.ToString());
        }

        [Fact]
        public async Task DeleteCustomerNotFound()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var result = await _controller.DeleteCustomer(id);

            // Assert
            var notFound = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Contains(id.ToString(), notFound?.Value?.ToString());
        }
    }
}