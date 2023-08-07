using Models;

namespace SportClubProject.UserRepository
{
    public interface IBookingRepo
    {
        public IEnumerable<BookingDetails> GetAllBookingDetails();
        public BookingDetails savebooking(BookingDetails bookingDetails);

        public List<BookingDetails> savebookingdetails(List<BookingDetails> bookingDetails);
    }
}
