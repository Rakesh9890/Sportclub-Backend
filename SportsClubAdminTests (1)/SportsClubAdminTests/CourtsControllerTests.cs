using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Moq;
using SportClubProject.AdminController;
using SportClubProject.AdminRepository;


namespace SportsClubAdminTests
{
    public class CourtsControllerTests
    {

        [Fact]
        public void GetAllCourts_ShouldReturnAllCourts()
        {
            // Arrange
            var courtsRepositoryMock = new Mock<ICourtsRepository>();
            var loggerMock = new Mock<ILogger<CourtsController>>();
            var controller = new CourtsController(courtsRepositoryMock.Object, loggerMock.Object);

            var mockCourts = new List<Courts>
            {
              new Courts { CourtId = 1, CourtName = "Court 1", category = "Indoor", CourtImageUrl = "image1.jpg", CourtPrice = 20.0, Status = "Available" },
              new Courts { CourtId = 2, CourtName = "Court 2", category = "Outdoor", CourtImageUrl = "image2.jpg", CourtPrice = 25.0, Status = "Booked" }
            };
            courtsRepositoryMock.Setup(repo => repo.GetAllCourts()).Returns(mockCourts);

            // Act
            var result = controller.GetAllCourts();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Courts>>(result); // Corrected assertion
            Assert.Equal(mockCourts.Count, result.Count());
        }




        [Fact]
        public void GetCourtBySportId_ShouldReturnCourtsForSportId()
        {
            // Arrange
            var courtsRepositoryMock = new Mock<ICourtsRepository>();
            var loggerMock = new Mock<ILogger<CourtsController>>();
            var controller = new CourtsController(courtsRepositoryMock.Object, loggerMock.Object);

            var sportId = 101;
            var mockCourts = new List<Courts>
            {
        new Courts { CourtId = 1, CourtName = "Court 1", category = "Indoor", CourtImageUrl = "image1.jpg", CourtPrice = 20.0, Status = "Available" },
        new Courts { CourtId = 2, CourtName = "Court 2", category = "Outdoor", CourtImageUrl = "image2.jpg", CourtPrice = 25.0, Status = "Booked" }
            };

            courtsRepositoryMock.Setup(repo => repo.getCourtBySportId(sportId)).Returns(mockCourts.Where(c => c.CourtId == sportId).ToList()); // Convert the filtered courts to a list

            // Act
            var result = controller.GetCourtBySportId(sportId);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Courts>>(result);
            Assert.Equal(mockCourts.Count(c => c.CourtId == sportId), result.Count());
        }



        [Fact]
        public void SaveCourt_ShouldSaveAndReturnSavedCourt()
        {
            // Arrange
            var courtsRepositoryMock = new Mock<ICourtsRepository>();
            var loggerMock = new Mock<ILogger<CourtsController>>();
            var controller = new CourtsController(courtsRepositoryMock.Object, loggerMock.Object);

            var courtToSave = new Courts { CourtId = 3, CourtName = "New Court", category = "Indoor", CourtImageUrl = "new_image.jpg", CourtPrice = 30.0, Status = "Available" };
            courtsRepositoryMock.Setup(repo => repo.SaveCourt(It.IsAny<Courts>())).Returns(courtToSave);

            // Act
            var result = controller.SaveCourt(courtToSave);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(courtToSave, okResult.Value);

        }


        [Fact]
        public void DeleteCourt_ShouldDeleteAndReturnDeletedCourt()
        {
            // Arrange
            var courtsRepositoryMock = new Mock<ICourtsRepository>();
            var loggerMock = new Mock<ILogger<CourtsController>>();
            var controller = new CourtsController(courtsRepositoryMock.Object, loggerMock.Object);

            var courtIdToDelete = 1;
            var courtToDelete = new Courts { CourtId = courtIdToDelete, CourtName = "Court 1", category = "Indoor", CourtImageUrl = "image1.jpg", CourtPrice = 20.0, Status = "Available" };
            courtsRepositoryMock.Setup(repo => repo.DeleteCourt(courtIdToDelete)).Returns(courtToDelete);

            // Act
            var result = controller.DeleteCourt(courtIdToDelete);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(courtToDelete, okResult.Value);
        }

    }
}
