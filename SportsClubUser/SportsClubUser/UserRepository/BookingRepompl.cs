using Models;
using SportClubProject.Repository;
using SportClubProject.Services;

namespace SportClubProject.UserRepository
{
    public class BookingRepompl:IBookingRepo
    {


        //sports dbcontext
        public readonly SportsDbContext sportsDbContext;

        //user service
        public readonly UserService userService;

        //logger
        public readonly ILogger<BookingRepompl> _logger;


        //injecting sports db context ,user service and logger
        public BookingRepompl(SportsDbContext sportsDbContext, UserService userService, ILogger<BookingRepompl> logger)
        {
            this.sportsDbContext = sportsDbContext;
            this.userService = userService;
            _logger = logger;
        }




        //get all Booking details
        public IEnumerable<BookingDetails> GetAllBookingDetails()
        {
            try
            {
                _logger.LogInformation("entered into get all booking details in booking repository implementation");
                return sportsDbContext.BookingDetails.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error occur while getting booking details in booking repository implementation");
                throw;
            }
        }



        //save booking
        public BookingDetails savebooking(BookingDetails bookingDetails)
        {
            try
            {
                _logger.LogInformation("entered into save booking method in booking repository implementation");
                sportsDbContext.BookingDetails.Add(bookingDetails);
                sportsDbContext.SaveChanges();
                return bookingDetails;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "error occur while saving bookingin booking repository implementation");
                throw;
            }
        }

      


        //save multiple booking
        List<BookingDetails> IBookingRepo.savebookingdetails(List<BookingDetails> bookingDetails)
        {
            try
            {
                _logger.LogInformation("entered into save booking details method in booking repository impl");
                sportsDbContext.BookingDetails.AddRange(bookingDetails);
                sportsDbContext.SaveChanges();
                return bookingDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"error occur while saving multiple bookings in booking repository impl");
                throw;
            }

        }
    }
}
