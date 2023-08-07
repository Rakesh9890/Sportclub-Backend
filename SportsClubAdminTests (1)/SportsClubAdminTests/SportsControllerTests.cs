using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Moq;
using SportClubProject.AdminController;
using SportClubProject.AdminRepository;


namespace SportsClubAdminTests
{
    public class SportsControllerTests
    {


        [Fact]
        public void GetAllSports_Should_Return_All_Sports()
        {
            // Arrange
            var sports = new List<Sports>
            {
                new Sports { SportId = 1, SportName = "Sport 1",SportImageUrl="cricketImage1",Status="Active" },
                new Sports { SportId = 2, SportName = "Sport 2" ,SportImageUrl="cricketImage2",Status="Active"}
            };
            var sportsRepositoryMock = new Mock<ISportsRepository>();
            sportsRepositoryMock.Setup(repo => repo.GetAllSports()).Returns(sports);
            var loggerMock = new Mock<ILogger<SportsController>>();
            var sportsController = new SportsController(sportsRepositoryMock.Object, loggerMock.Object);

            // Act
            var result = sportsController.GetAllSports();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<Sports>>(result);
        }



        [Fact]
        public void GetSportByStadiumId_Should_Return_Sports_For_Valid_StadiumId()
        {
            // Arrange
            int stadiumId = 1;
            var sportsForStadium = new List<Sports>
            {
                new Sports { SportId = 1, SportName = "cricket", SportImageUrl = "cricketImage1", Status = "Active" },
                new Sports { SportId = 2, SportName = "football", SportImageUrl = "footballImage2", Status = "Active" }
            };
            var sportsRepositoryMock = new Mock<ISportsRepository>();
            sportsRepositoryMock.Setup(repo => repo.GetSportByStadiumId(stadiumId)).Returns(sportsForStadium);
            var loggerMock = new Mock<ILogger<SportsController>>();
            var sportsController = new SportsController(sportsRepositoryMock.Object, loggerMock.Object);

            // Act
            var result = sportsController.GetSportByStadiumId(stadiumId);

            // Assert
            Assert.IsAssignableFrom<IEnumerable<Sports>>(result);
            var returnedSports = Assert.IsAssignableFrom<IEnumerable<Sports>>(result);
            Assert.Equal(sportsForStadium.Count, returnedSports.Count());
        }



        [Fact]
        public void SaveSport_Should_Return_OkResult_With_SavedSport()
        {
            // Arrange
            var newSport = new Sports { SportName = "New Sport" };
            var sportsRepositoryMock = new Mock<ISportsRepository>();
            sportsRepositoryMock.Setup(repo => repo.SaveSport(It.IsAny<Sports>())).Returns(newSport);
            var loggerMock = new Mock<ILogger<SportsController>>();
            var sportsController = new SportsController(sportsRepositoryMock.Object, loggerMock.Object);

            // Act
            var result = sportsController.SaveSport(newSport);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var savedSport = Assert.IsType<Sports>(okResult.Value);
            Assert.Equal("New Sport", savedSport.SportName);
        }


        [Fact]
        public void SaveSportByStadiumId_Should_Return_OkResult_With_SavedSport()
        {
            // Arrange
            int stadiumId = 1;
            var newSport = new Sports { SportName = "New Sport" };
            var sportsRepositoryMock = new Mock<ISportsRepository>();
            sportsRepositoryMock.Setup(repo => repo.SaveSportByStadiumId(stadiumId, It.IsAny<Sports>())).Returns(newSport);
            var loggerMock = new Mock<ILogger<SportsController>>();
            var sportsController = new SportsController(sportsRepositoryMock.Object, loggerMock.Object);

            // Act
            var result = sportsController.SaveSportByStadiumId(stadiumId, newSport);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var savedSport = Assert.IsType<Sports>(okResult.Value);
            Assert.Equal("New Sport", savedSport.SportName);
        }
    }
}
