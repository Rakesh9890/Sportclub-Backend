
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using global::SportClubProject.AdminRepository;
using global::SportClubProject.AdminController;

namespace SportsClubAdminTests
{
    

   
        public class SlotsControllerTests
        {
            [Fact]
            public void GetAllSlots_ShouldReturnAllSlots()
            {
                // Arrange
                var slotsRepositoryMock = new Mock<ISlotsRepository>();
                var loggerMock = new Mock<ILogger<SlotsController>>();
                var controller = new SlotsController(slotsRepositoryMock.Object, loggerMock.Object);

                var mockSlots = new List<Slots>
            {
                new Slots { SlotId = 1, SlotTime = "10:00 AM", Day = "Monday" },
                new Slots { SlotId = 2, SlotTime = "02:30 PM", Day = "Tuesday" }
            };
                slotsRepositoryMock.Setup(repo => repo.GetAllSlots()).Returns(mockSlots);

                // Act
                var result = controller.GetAllSlots();

                // Assert
                Assert.NotNull(result);
                Assert.IsAssignableFrom<IEnumerable<Slots>>(result);
                Assert.Equal(mockSlots.Count, result.Count());
            }

            [Fact]
            public void SaveSlot_ShouldSaveAndReturnSavedSlot()
            {
                // Arrange
                var slotsRepositoryMock = new Mock<ISlotsRepository>();
                var loggerMock = new Mock<ILogger<SlotsController>>();
                var controller = new SlotsController(slotsRepositoryMock.Object, loggerMock.Object);

                var slotToSave = new Slots { SlotId = 3, SlotTime = "05:00 PM", Day = "Wednesday" };
                slotsRepositoryMock.Setup(repo => repo.SaveSlot(It.IsAny<Slots>())).Returns(slotToSave);

                // Act
                var result = controller.SaveSlot(slotToSave);

                // Assert
                Assert.NotNull(result);
                Assert.IsType<OkObjectResult>(result);
                var okResult = (OkObjectResult)result;
                Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
                Assert.Equal(slotToSave, okResult.Value);
            }

            [Fact]
            public void DeleteSlot_ShouldDeleteAndReturnDeletedSlot()
            {
                // Arrange
                var slotsRepositoryMock = new Mock<ISlotsRepository>();
                var loggerMock = new Mock<ILogger<SlotsController>>();
                var controller = new SlotsController(slotsRepositoryMock.Object, loggerMock.Object);

                var slotIdToDelete = 1;
                var slotToDelete = new Slots { SlotId = slotIdToDelete, SlotTime = "10:00 AM", Day = "Monday" };
                slotsRepositoryMock.Setup(repo => repo.DeleteSlot(slotIdToDelete)).Returns(slotToDelete);

                // Act
                var result = controller.DeleteSlot(slotIdToDelete);

                // Assert
                Assert.NotNull(result);
                Assert.IsType<OkObjectResult>(result);
                var okResult = (OkObjectResult)result;
                Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
                Assert.Equal(slotToDelete, okResult.Value);
            }

            
        }
    

}
