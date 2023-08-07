using Models;

namespace SportsClubAdmin.AdminRepository
{
    public interface IDashBoardRepo
    {

        public int BookingsCount();
        
        public int UsersCount();

        public double RevenueGenerated();


        public IEnumerable<BookingDetails> GetBookingDetails();
        public IEnumerable<UserDetails> GetUserDetails();
        public List<int> getcourtscount(string name, string date);

        public List<int> getbookingspermonth();
    }
}
