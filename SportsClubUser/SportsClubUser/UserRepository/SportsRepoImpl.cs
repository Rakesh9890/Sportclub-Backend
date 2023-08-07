using Microsoft.EntityFrameworkCore;
using Models;
using SportClubProject.Repository;
using SportClubProject.Services;

namespace SportClubProject.UserRepository
{
    public class SportsRepoImpl:ISportsRepo
    {
        //sports dbcontext
        public readonly SportsDbContext sportsDbContext;


        //logger
        public readonly ILogger<SportsRepoImpl> logger;

        //user service
        public readonly UserService userService;

        //injecting sportsdbcontsext,userservice,logger
        public SportsRepoImpl(SportsDbContext sportsDbContext, UserService userService, ILogger<SportsRepoImpl> logger)
        {
            this.sportsDbContext = sportsDbContext;
            this.userService = userService;
            this.logger = logger;
        }

        //get sport by stadiumid
        public List<Sports> GetSportByStadiumId(int stadiumId)
        {

            /*Stadiums stadiums = sportsDbContext.Stadiums.Include(s => s.Sports).FirstOrDefault(stadium => stadium.StadiumId == stadiumId);
            List<Sports> sports = stadiums.Sports.
            return sports;*/
            try
            {
                logger.LogInformation("entered into get sport by stadium id in sports repo impl");
                var stadiums = sportsDbContext.Stadiums.Include(s => s.Sports).ThenInclude(e => e.Courts).FirstOrDefault(e => e.StadiumId == stadiumId);
                return stadiums.Sports.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error occur while get sport by stadium id in sports repo impl");
                throw;
            }
        }




        //get sports 
        public IEnumerable<Sports> GetAllSports()
        {
            try
            {
                logger.LogInformation("entered into get all sports method in sports repo impl");
                return sportsDbContext.Sports.Include(e => e.Courts).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error occur while get all sports in sports repo impl");
                throw;
            }
        }

    }
}
