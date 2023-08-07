using SportClubProject.Repository;
using SportClubProject.Services;

namespace SportClubProject.UserRepository
{
    public class SlotsRepoImpl:ISlotsRepo
    {
        //sports dbcontext
        public readonly SportsDbContext sportsDbContext;

        //logger
        public readonly ILogger<SlotsRepoImpl> logger;

        //user service
          public readonly UserService userService;
  
        //injecting sports db context,user service and logger
        public SlotsRepoImpl(SportsDbContext sportsDbContext, UserService userService, ILogger<SlotsRepoImpl> logger)
        {
            this.sportsDbContext = sportsDbContext;
            this.userService = userService;
            this.logger = logger;
        }



        //getting all slots
        public List<string> GetSlots(string SportName, string date, string CourtName)
        {
            try
            {
                logger.LogInformation("entered into get slots method in slot repo impl");
                return userService.GetSlots(SportName, date, CourtName);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error occur while get slots in slot repo impl");
                throw;
            }

        }

    }
}
