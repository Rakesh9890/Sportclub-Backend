using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Moq;
using SportClubProject.UserControllers;
using SportClubProject.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClubUserTests
{
    public class CartControllerTests
    {

        [Fact]
        public void GetAllCarts_ShouldReturnAllCartsForUser()
        {
            // Arrange
            var cartsRepositoryMock = new Mock<ICartsRepo>();
            var loggerMock = new Mock<ILogger<CartsController>>();
            var controller = new CartsController(cartsRepositoryMock.Object, loggerMock.Object);

            var userId = 101;
            var mockCarts = new List<Cart>
            {
                new Cart { CartId = 1, UserId = userId, SportName = "Tennis", SlotTime = "10:00 AM", CourtName = "Court 1", Price = 20.0 },
                new Cart { CartId = 2, UserId = userId, SportName = "Football", SlotTime = "02:30 PM", CourtName = "Field A", Price = 15.0 }
            };
            cartsRepositoryMock.Setup(repo => repo.GetAllCarts(userId)).Returns(mockCarts);

            // Act
            var result = controller.GetAllCarts(userId);
            // Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualCarts = Assert.IsAssignableFrom<List<Cart>>(okResult.Value);
            Assert.Equal(mockCarts.Count, actualCarts.Count());
            Assert.Equal(userId, actualCarts.First().UserId);
        }

    }
    
}

