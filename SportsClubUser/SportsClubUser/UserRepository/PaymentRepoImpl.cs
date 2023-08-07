using Models;
using SportClubProject.Repository;
using SportClubProject.Services;

namespace SportClubProject.UserRepository
{
    public class PaymentRepoImpl:IPaymentRepo
    {
        //sports dbcontext
        public readonly SportsDbContext sportsDbContext;

        //logger
        public readonly ILogger<PaymentRepoImpl> logger;

        //user service
         public readonly UserService userService;
        public PaymentRepoImpl(SportsDbContext sportsDbContext, UserService userService, ILogger<PaymentRepoImpl> logger)
        {
            this.sportsDbContext = sportsDbContext;
            this.userService = userService;
            this.logger = logger;
        }

        public List<Payment> GetPaymentList()
        {
           return sportsDbContext.payments.ToList();
        }


        //saving payment details
        public Payment SavePaymentDetails(Payment payment)
        {
            try
            {
                logger.LogInformation("entered into save payment details in payment repo impl");
                sportsDbContext.Add(payment);
                sportsDbContext.SaveChanges();
                return payment;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error occur while saving payment in payment repo impl");
                throw;
            }
        }
    }
}
