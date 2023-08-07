using Microsoft.Identity.Client;
using Models;
using SportClubProject.Repository;
using System.Security.Cryptography.X509Certificates;

namespace SportsClubAdmin.AdminRepository
{
    public class DashBoardRepoImpl : IDashBoardRepo
    {
        //sport db context
        private readonly SportsDbContext sportsDbContext;

        //logger
        private readonly ILogger<DashBoardRepoImpl> logger;

        //injecting sportsdbcontext and logger
        public DashBoardRepoImpl(SportsDbContext sportsDbContext, ILogger<DashBoardRepoImpl> logger)
        {
            this.sportsDbContext = sportsDbContext;
            this.logger = logger;
        }


        //get booking count
        public int BookingsCount()
        {
            try
            {
                logger.LogInformation("entered into bookings count method in dash board repo impl");
                int noofbookings = sportsDbContext.BookingDetails.Count();
                return noofbookings;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error occured while getting bookings count in dash board repo impl");
                throw;
            }
        }


        //get revenue
        public double RevenueGenerated()
        {
            try
            {
                logger.LogInformation("entered into revenue genarated method in dashboard repo impl  ");
                double totalprice = sportsDbContext.payments.Sum(e => e.Amount);
                return totalprice;
            }
            catch (Exception ex)
            {
                logger.LogError(ex,"error occured while genarating revenue");
                throw;

            }
        }


        //get users count
        public int UsersCount()
        {
            try
            {
                logger.LogInformation("entered into users count method in dashboard repo impl");
                int noofusers = sportsDbContext.UserDetails.Count();
                return noofusers;
            }
            catch(Exception ex)
            {
                logger.LogError(ex,"error occured while getting users count");
                throw;
            }
        }


        //get booking details
        public IEnumerable<BookingDetails> GetBookingDetails()
        {
            try
            {
                logger.LogInformation("entered into get booking details in dash board repo impl");
                return sportsDbContext.BookingDetails.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex,"error occur while getting booking details");
                throw;
            }
        }


        //get user details
        public IEnumerable<UserDetails> GetUserDetails()
        {
            try
            {
                logger.LogInformation("entered into get user details method in dash board repo impl");
                return sportsDbContext.UserDetails.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error occured while getting user details");
                throw;
            }
        }

        public List<int> getcourtscount(string sportname, string date)
        {
            List<Courts> courts = new List<Courts>();
            List<string> totalcourts = new List<string>();
            List<Int32> resultcourts = new List<Int32>();
            var res = sportsDbContext.Sports.Where(e => e.SportName.Equals(sportname)).Select(e => e.Courts).ToList();
            foreach (var coupon in res)
            {
                foreach (var val in coupon)
                {
                    courts.Add(val);
                }
            }
            List<string> courtlist = sportsDbContext.BookingDetails.Where(e => e.SportName.Equals(sportname) && e.Bookingdate.Equals(date)).Select(e => e.CourtName).ToList();
            foreach (var court in courts)
            {
                int count = 0;
                foreach (string courtname in courtlist)
                {
                    if (court.CourtName.Equals(courtname))
                    {
                        count++;
                    }
                    resultcourts.Add((count / 4) * 100);
                }

            }
            return resultcourts;
        }

    

        public List<int> getbookingspermonth()
        {
            try
            {
                logger.LogInformation("entered into get getcourtscount method in dash board repo impl");
                List<int> result = new List<int>();
                Int32[] arr = new Int32[12];
                List<BookingDetails> bookingDetails = sportsDbContext.BookingDetails.ToList();
                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < bookingDetails.Count; j++)
                    {
                        string datevalue = bookingDetails[j].Bookingdate.Split('/')[1];
                        if (datevalue.Equals((string)"0" + (i + 1)))
                        {
                            arr[i]++;
                        }
                    }
                }
                result = arr.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
