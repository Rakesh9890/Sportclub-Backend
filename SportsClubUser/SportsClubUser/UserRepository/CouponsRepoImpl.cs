using Models;
using SportClubProject.Repository;
using SportClubProject.Services;

namespace SportClubProject.UserRepository
{
    public class CouponsRepoImpl:ICouponsRepo
    {

        //sports dbcontext
        public readonly SportsDbContext sportsDbContext;

        //logger
        public readonly ILogger<CouponsRepoImpl> logger;

        //user service
          public readonly UserService userService;

        //injecting sports db context,user service and logger
        public CouponsRepoImpl(SportsDbContext sportsDbContext, UserService userService, ILogger<CouponsRepoImpl> logger)
        {
            this.sportsDbContext = sportsDbContext;
            this.userService = userService;
            this.logger = logger;
        }



        //getting all coupons
        public IEnumerable<Coupons> GetAllCoupons()
        {
            try
            {
                logger.LogInformation("entered into get all coupons method in coupons repo impl");
                return sportsDbContext.Coupons.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error occur while getting all coupons in coupons repo impl");
                throw;
            }
        }


    }
}
