using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using SportClubProject.Repository;
using SportClubProject.UserRepository;


namespace SportClubProject.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepo BookingRepository;
        private readonly ILogger<BookingController> _logger;


        //injecting booking repository and logger
        public BookingController(IBookingRepo bookingRepository, ILogger<BookingController> logger)
        {
            BookingRepository = bookingRepository;
            _logger = logger;
        }

       
        
        
        // Getting all booking details from repository
        [HttpGet("getbookingdetais")]
        public ActionResult<IEnumerable<BookingDetails>> GetAllBookingDetails()
        {
            try
            {
                _logger.LogInformation("entered get booking detail method in booking controller");
                return BookingRepository.GetAllBookingDetails().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all booking details.");
                throw;
            }
        }

        
        
        //save booking
        [HttpPost("savebookingdetail")]
        public IActionResult SaveBookingDetail(BookingDetails bookingDetails)
        {
            try
            {
                _logger.LogInformation("entered save booking detail method in booking controller");
                var savedBooking = BookingRepository.savebooking(bookingDetails);
                return Ok(savedBooking);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving booking detail.");
                return BadRequest(ex.Message);
            }
        }

        
        
        //save multiple bookings
        
        [HttpPost("savebookingdetails")]
        public IActionResult SaveBookingDetails(List<BookingDetails> allBookingDetails)
        {
            try
            {
                _logger.LogInformation("entered save multiple booking details method in booking controller");
                var savedBookings = BookingRepository.savebookingdetails(allBookingDetails);
                return Ok(savedBookings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving booking details.");
                return BadRequest(ex.Message);
            }
        }
    }
}
