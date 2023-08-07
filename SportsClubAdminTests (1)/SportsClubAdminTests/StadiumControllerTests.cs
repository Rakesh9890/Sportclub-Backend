using Castle.Core.Logging;

using Moq;
using SportClubProject.AdminController;
using SportClubProject.AdminRepository;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace SportsClubAdminTests
{
    public class StadiumControllerTests
    {
        [Fact]
        public void GetAllStadiums_Should_Return_All_Stadiums()
        {
            // Arrange
            var stadiums = new List<Stadiums>
            {
                new Stadiums { StadiumId = 1, StadiumName = "Stadium 1", Location = "Location 1" },
                new Stadiums { StadiumId = 2, StadiumName = "Stadium 2", Location = "Location 2" }
            };

            var stadiumsRepositoryMock = new Mock<IStadiumsRepository>();
            stadiumsRepositoryMock.Setup(repo => repo.GetAllStadiums()).Returns(stadiums);
            var loggerMock = new Mock<ILogger<StadiumController>>();
            var stadiumController = new StadiumController(stadiumsRepositoryMock.Object, loggerMock.Object);

            // Act
            var result = stadiumController.GetAllStadiums();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<Stadiums>>(result); 
        }



        [Fact]
        public void SaveStadium_Should_Return_OkResult()
        {
            // Arrange
            var newStadium = new Stadiums { StadiumName = "New Stadium", Location = "New Location" };
            var stadiumsRepositoryMock = new Mock<IStadiumsRepository>();
            stadiumsRepositoryMock.Setup(repo => repo.SaveStadium(It.IsAny<Stadiums>())).Returns(newStadium);
            var loggerMock = new Mock<ILogger<StadiumController>>();
            var stadiumController = new StadiumController(stadiumsRepositoryMock.Object, loggerMock.Object);

            // Act
            var result = stadiumController.SaveStadium(newStadium);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }



        [Fact]
        public void DeleteStadium_Should_Return_OkResult()
        {
            // Arrange
            int stadiumIdToDelete = 1;
            var deletedStadium = new Stadiums { StadiumId = stadiumIdToDelete, StadiumName = "Stadium to delete", Location = "Location to delete" };
            var stadiumsRepositoryMock = new Mock<IStadiumsRepository>();
            stadiumsRepositoryMock.Setup(repo => repo.DeleteStadium(stadiumIdToDelete)).Returns(deletedStadium);
            var loggerMock = new Mock<ILogger<StadiumController>>();
            var stadiumController = new StadiumController(stadiumsRepositoryMock.Object, loggerMock.Object);

            // Act
            var result = stadiumController.DeleteStadium(stadiumIdToDelete);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
 }
