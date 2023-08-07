using Microsoft.Extensions.Logging;
using Models;
using SportClubProject.UserControllers;
using SportClubProject.UserRepository;
using System;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SportsClubUserTests
{
    public class BookingControllerTests
    {
        
        [Fact]
        public void SaveBookingDetail_ShouldSaveAndReturnSavedBookingDetail()
        {
            // Arrange
            var bookingRepositoryMock = new Mock<IBookingRepo>();
            var loggerMock = new Mock<ILogger<BookingController>>();
            var controller = new BookingController(bookingRepositoryMock.Object, loggerMock.Object);

            var bookingToSave = new BookingDetails { BookingId = 3, Bookingdate = "2023-08-01", SportName = "Basketball", SlotTime = "05:00 PM", CourtName = "Court B", UserId = 103 };
            bookingRepositoryMock.Setup(repo => repo.savebooking(bookingToSave)).Returns(bookingToSave);

            // Act
            var result = controller.SaveBookingDetail(bookingToSave);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(bookingToSave, okResult.Value);

        }
    }
}

