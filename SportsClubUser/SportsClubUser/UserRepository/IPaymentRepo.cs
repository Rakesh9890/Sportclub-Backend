using Models;

namespace SportClubProject.UserRepository
{
    public interface IPaymentRepo
    {
        public Payment SavePaymentDetails(Payment payment);


        public List<Payment> GetPaymentList();
    }
}
