using Models;
using SportClubProject.Repository;
using SportClubProject.Services;

namespace SportClubProject.UserRepository
{
    public class CourtsRepoImplcs:ICourtsRepo
    {

        //sports dbcontext
        public readonly SportsDbContext sportsDbContext;

        //logger
        public readonly ILogger<CourtsRepoImplcs> logger;

        //user service
        public readonly UserService userService;

        public CourtsRepoImplcs(SportsDbContext sportsDbContext, UserService userService, ILogger<CourtsRepoImplcs> logger)
        {
            this.userService = userService;
            this.sportsDbContext = sportsDbContext;
            this.logger = logger;
        }

        //getting all courts
        public List<Courts> GetAllCourts(string SportName, string date)
        {
            try
            {
                logger.LogInformation("entered into get all courts method in courts repo impl");
                return userService.GetCourts(SportName, date);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error occur while getting all courts in courts repo impl");
                throw;
            }
        }
    }
}
