// Import the necessary namespaces for testing

using Moq;
using Microsoft.Extensions.Logging;
using SportsClubAdmin.AdminController;
using SportsClubAdmin.AdminRepository;


namespace SportsClubAdmin.Tests
{
    public class DashBoardControllerTests
    {
        [Fact]
        public void GetBookingCount_ShouldReturnNumberOfBookings()
        {
            // Arrange
            var dashBoardRepoMock = new Mock<IDashBoardRepo>();
            var loggerMock = new Mock<ILogger<DashBoardController>>();
            var controller = new DashBoardController(dashBoardRepoMock.Object, loggerMock.Object);

            var mockBookingCount = 10;
            dashBoardRepoMock.Setup(repo => repo.BookingsCount()).Returns(mockBookingCount);

            // Act
            var result = controller.GetBookingCount();

            // Assert
            Assert.Equal(mockBookingCount, result);
        }

        [Fact]
        public void GetUserCount_ShouldReturnNumberOfUsers()
        {
            // Arrange
            var dashBoardRepoMock = new Mock<IDashBoardRepo>();
            var loggerMock = new Mock<ILogger<DashBoardController>>();
            var controller = new DashBoardController(dashBoardRepoMock.Object, loggerMock.Object);

            var mockUserCount = 5;
            dashBoardRepoMock.Setup(repo => repo.UsersCount()).Returns(mockUserCount);

            // Act
            var result = controller.GetUserCount();

            // Assert
            Assert.Equal(mockUserCount, result);
        }

        [Fact]
        public void GetRevenue_ShouldReturnTotalRevenue()
        {
            // Arrange
            var dashBoardRepoMock = new Mock<IDashBoardRepo>();
            var loggerMock = new Mock<ILogger<DashBoardController>>();
            var controller = new DashBoardController(dashBoardRepoMock.Object, loggerMock.Object);

            var mockRevenue = 1000.0;
            dashBoardRepoMock.Setup(repo => repo.RevenueGenerated()).Returns(mockRevenue);

            // Act
            var result = controller.GetRevenue();

            // Assert
            Assert.Equal(mockRevenue, result);
        }

       
    }
}
