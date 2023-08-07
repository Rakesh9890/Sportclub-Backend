using Microsoft.EntityFrameworkCore;
using Models;
using SportClubProject.Repository;

namespace SportClubProject.AdminRepository
{
    public class StadiumRepositoryImpl :IStadiumsRepository
    {
        //sports dbcontext
        private readonly SportsDbContext sportsDbContext;

        //loggers
        private readonly ILogger<StadiumRepositoryImpl> logger;

        //injecting sportsdbcontext and logger
        public StadiumRepositoryImpl(SportsDbContext sportsDbContext, ILogger<StadiumRepositoryImpl> logger)
        {
            this.sportsDbContext = sportsDbContext;
            this.logger = logger;
        }

        //get all stadiums
        public IEnumerable<Stadiums> GetAllStadiums()
        {
            try
            {
                logger.LogInformation("entered into get all stadiums method in stadium repository impl");
                return sportsDbContext.Stadiums.Include(e => e.Sports).ThenInclude(e => e.Courts);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching all stadiums");
                throw;
            }
           
        }


        //save stadium
        public Stadiums SaveStadium(Stadiums stadium)
        {
            try
            {
                logger.LogInformation("entered into save stadium method in stadium repository impl");
                sportsDbContext.Add(stadium);
                sportsDbContext.SaveChanges();
                return stadium;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while saving stadium");
                throw;
            }
           
        }



        //delete stadium by id
        public Stadiums DeleteStadium(int stadiumId)
        {
            try
            {
                logger.LogInformation("entered into delete stadium method in stadium repository impl");
                Stadiums stadium = sportsDbContext.Stadiums.Find(stadiumId);
                if (stadium != null)
                {
                    sportsDbContext.Stadiums.Remove(stadium);
                    sportsDbContext.SaveChanges();
                }
                return stadium;
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting stadium with ID {StadiumId}", stadiumId);
                throw;
            }
        }
    }
}
