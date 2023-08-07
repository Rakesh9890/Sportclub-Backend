using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using SportsClubAdmin.AdminRepository;

namespace SportsClubAdmin.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
       
        private readonly IDashBoardRepo dashBoardRepo;

        //logger
        private readonly ILogger<DashBoardController> _logger;


        //injecting logger and dashboard repository through constructor injection
        public DashBoardController(IDashBoardRepo dashBoardRepo, ILogger<DashBoardController> logger)
        {
            this.dashBoardRepo = dashBoardRepo;
            _logger = logger;
        }



        //getting number of bookings from dashboard repository
        [HttpGet("getnumberofbookings")]
        public int GetBookingCount()
        {
            try
            {
               _logger.LogInformation("entered into get booking count method in dash board controller");
                int bookingcount = dashBoardRepo.BookingsCount();
                return bookingcount;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ann error occured while getting bookings");
                throw;
            }
        }



        //getting number of users from dasgboard repository
        [HttpGet("getnumberofusers")]
        public int GetUserCount()
        {
            try
            {
               _logger.LogInformation("entered user count method in dashboard controller");
                int userscount = dashBoardRepo.UsersCount();
                return userscount;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "an error occur while getting number of users");
                throw;
            }
        }


        //getting total payment
        [HttpGet("getrevenue")]
        public double GetRevenue()
        {
            try
            {
                _logger.LogInformation("entered get revenue method in dashboard controller");
                double totalprice = dashBoardRepo.RevenueGenerated();
                return totalprice;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "an error occuring while getting revenue");
                throw;
            }
        }


        //get all  bookings in admin dashboard
        [HttpGet("getbookings")]
        public IEnumerable<BookingDetails> GetBookingDetails()
        {
            try
            {
                _logger.LogInformation("enterded get booking details method");
                IEnumerable<BookingDetails> bookings = dashBoardRepo.GetBookingDetails().ToList();
                return bookings;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "an error occur while getting bookings");
                throw;
            }

        }


        //getting users
        [HttpGet("getusers")]
        public IEnumerable<UserDetails> GetUserDetails()
        {
            try
            {
                _logger.LogInformation("enterd get user details method");
                IEnumerable<UserDetails> userDetails = dashBoardRepo.GetUserDetails().ToList();
                return userDetails;
            }
            catch (Exception ex) {
                _logger.LogError(ex, "an error occur while get users");
                throw;
            }


        }
        [HttpGet("bookingspermonth")]
        public List<Int32> getbookingspermonth()
        {
            try
            {
                _logger.LogInformation("enterd get bookings details method");
                return dashBoardRepo.getbookingspermonth().ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "an error occur while get bookings");
                throw;
            }
        }

        [HttpGet("avialblecourts")]
        public List<Int32> avialblecourts(string name, string date)
        {
            try
            {
                _logger.LogInformation("enterd get avilable courts method");
                return dashBoardRepo.getcourtscount(name, date);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "an error occur while get courts");
                throw;
            }
        }



    }
}
