using Microsoft.EntityFrameworkCore;
using Models;
using SportClubProject.Repository;

namespace SportClubProject.AdminRepository
{
    public class SportRepositoryImpl:ISportsRepository
    {


        //sports dbcontext
        private readonly SportsDbContext sportsDbContext;

        //logger
        private readonly ILogger<SportRepositoryImpl> logger;

        public SportRepositoryImpl(SportsDbContext sportsDbContext, ILogger<SportRepositoryImpl> logger)
        {
            this.sportsDbContext = sportsDbContext;
            this.logger = logger;
        }


        //get all sports

        public IEnumerable<Sports> GetAllSports()
        {
            try
            {
                logger.LogInformation("entered into get all sports method in sports repository impl");
                return sportsDbContext.Sports.Include(x => x.Courts);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching all sports");
                throw;
            }
        }


        //get sport by id
        public Sports GetSportById(int id)
        {
            try
            {
                logger.LogInformation("entered into getsportbyid method in sports repository impl");
                return sportsDbContext.Sports.Find(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching sport by ID {SportId}", id);
                throw;
            }
        }


        //save sport
        public Sports SaveSport(Sports sport)
        {
            try
            {
                logger.LogInformation("entered into save sport method in sport repository impl");
                sportsDbContext.Sports.Add(sport);
                sportsDbContext.SaveChanges();
                return sport;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while saving sport");
                throw;
            }
        }


        //delete sport by id
        public Sports DeleteSport(int id)
        {
            try
            {
                Sports sport = sportsDbContext.Sports.Find(id);
                if (sport != null)
                {
                    sportsDbContext.Sports.Remove(sport);
                    sportsDbContext.SaveChanges();
                }
                return sport;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting sport with ID {SportId}", id);
                throw;
            }
        }



        //update sport
        

        public Sports UpdateSport(Sports sport, int id)
        {
            try
            {
                logger.LogInformation("entered into update sport method in sport repository impl");
                var existingSport = sportsDbContext.Sports.FirstOrDefault(s => s.SportId == id);
                if (existingSport != null)
                {
                    existingSport.SportName = sport.SportName;
                    existingSport.SportImageUrl = sport.SportImageUrl;
                    existingSport.SportName = sport.Status;
                    sportsDbContext.SaveChanges();
                }
                return existingSport;
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating sport with ID {SportId}", id);
                throw;
            }
        }



        //save sport by stadium id
        public Sports SaveSportByStadiumId(int stadiumId, Sports sport)
        {
            try
            {
                logger.LogInformation("entered into savesport by stadium id in sports repository impl");
                Stadiums stadiums = sportsDbContext.Stadiums.Include(s => s.Sports).FirstOrDefault(stadium => stadium.StadiumId == stadiumId);
                if (stadiums == null)
                {
                    throw new ArgumentException("Invalid stadium ID");
                }
                stadiums.StadiumId = stadiumId;
                stadiums.Sports.Add(sport);
                sportsDbContext.SaveChanges();
                return sport;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while saving sport by stadium ID {StadiumId}", stadiumId);
                throw;
            }

        }


        //get sport by stadium id
        public List<Sports> GetSportByStadiumId(int stadiumId)
        {
            // Converting null literal or possible null value to non-nullable type.
            #pragma warning disable CS8600
            try
            {
                logger.LogInformation("entered into get sport by stadium id in sport repository impl");
                Stadiums stadiums = sportsDbContext.Stadiums.Include(s => s.Sports).FirstOrDefault(stadium => stadium.StadiumId == stadiumId);
                List<Sports> sports = stadiums.Sports.ToList();
                return sports;
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error occurred while fetching sports by stadium ID {StadiumId}", stadiumId);
                throw;
            }
        }

    }
}

