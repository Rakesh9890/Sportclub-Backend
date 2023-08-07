using Microsoft.EntityFrameworkCore;
using Models;
using SportClubProject.Repository;

namespace SportClubProject.AdminRepository
{
    public class CourtsRepositoryImpl:ICourtsRepository
    {

        //sports dbcontext
       private readonly SportsDbContext sportsDbContext;

        //logger
        private readonly ILogger<CourtsRepositoryImpl> _logger;

        public CourtsRepositoryImpl(SportsDbContext sportsDbContext, ILogger<CourtsRepositoryImpl> logger)
        {
            this.sportsDbContext = sportsDbContext;
            _logger = logger;
        }


        //get court by sport id
        public List<Courts> getCourtBySportId(int sportId)
        {
            // Converting null literal or possible null value to non-nullable type.
            #pragma warning disable CS8600
            try
            {
                _logger.LogInformation("entered into get courtby sport id method in courts repository implementation");
                Sports sports = sportsDbContext.Sports.Include(s => s.Courts).FirstOrDefault(sport => sport.SportId == sportId);
                List<Courts> courts = sports.Courts.ToList();
                return courts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error occur while get court by sport id");
                throw;
            }
        }




        //save court by sport id
        public Courts SaveCourtBySportId(int sportId, Courts court)
        {
            try
            {
                _logger.LogInformation("entered save court by sport id");
                Sports sports = sportsDbContext.Sports.Include(s => s.Courts).FirstOrDefault(sport => sport.SportId == sportId);
                if (sports == null)
                {
                    throw new ArgumentException("Invalid sport ID");
                }
                sports.SportId = sportId;
                sports.Courts.Add(court);
                sportsDbContext.SaveChanges();
                return court;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"error occur while saving court by sport id");
                throw;
            }

        }



        //get all courts
        public IEnumerable<Courts> GetAllCourts()
        {
            try
            {
                _logger.LogInformation("entered into get all courts method in courts repository impl");
                return sportsDbContext.Courts.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"error occur while get all courts in courts repository impl");
                throw;
            }
        }




        //save court
        public Courts SaveCourt(Courts court)
        {
            try
            {
                _logger.LogInformation("entered into save court method in courts repository impl");
                sportsDbContext.Courts.Add(court);
                sportsDbContext.SaveChanges();
                return court;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"error occured while save court in courts repository impl ");
                throw;
            }
        }

        //delete court
        public Courts DeleteCourt(int id)
        {
            try
            {
                Courts court = sportsDbContext.Courts.Find(id);
                if (court != null)
                {
                    sportsDbContext.Courts.Remove(court);
                    sportsDbContext.SaveChanges();
                }
                return court;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting court with ID {CourtId}", id);
                throw; 
            }
        }



        //update court
        public Courts UpdateCourt(Courts court,int CourtId)
        {
            {
                try
                {
                    var existingCourt = sportsDbContext.Courts.FirstOrDefault(s => s.CourtId == CourtId);
                    if (existingCourt != null)
                    {
                        existingCourt.CourtName = court.CourtName;
                        existingCourt.CourtImageUrl = court.CourtImageUrl;
                        existingCourt.CourtPrice = court.CourtPrice;
                        sportsDbContext.SaveChanges();
                    }
                    return existingCourt;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while updating court with ID {CourtId}", CourtId);
                    throw; 
                }
            }
        }
    }

    }



