
using Microsoft.AspNetCore.Mvc;
using Models;
using SportClubProject.AdminRepository;


namespace SportClubProject.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly ISportsRepository sportsRepository;
        private readonly ILogger<SportsController> _logger; // Add ILogger

        public SportsController(ISportsRepository sportsRepository, ILogger<SportsController> logger)
        {
            this.sportsRepository = sportsRepository;
            _logger = logger; // Inject ILogger
        }

        
        //get all sports
        
        [HttpGet("getallsports")]
        public IEnumerable<Sports> GetAllSports()
        {
            try
            {
                _logger.LogInformation("entered into get all sports method");
                IEnumerable<Sports> sports = sportsRepository.GetAllSports().ToList();
                return sports;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all sports.");
                throw;
            }
        }

        
        
        //get sport by stadium id
        [HttpGet("getsportbystadiumid")]
        public IEnumerable<Sports> GetSportByStadiumId(int stadiumId)
        {
            try
            {

                _logger.LogInformation("entered into get sport by stadium id");
                IEnumerable<Sports> sports = sportsRepository.GetSportByStadiumId(stadiumId);
                return sports;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting sports for stadium ID: {stadiumId}.");
                throw;
            }
        }

        
        
        //save sport
        [HttpPost("savesport")]
        public IActionResult SaveSport(Sports sports)
        {
            try
            {
                _logger.LogInformation("entered into save sport method");
                Sports savedSport = sportsRepository.SaveSport(sports);
                return Ok(savedSport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving sport.");
                return BadRequest(ex.Message);
            }
        }

       
        
        
        
        //delete sport
        [HttpDelete("deletesport")]
        public IActionResult DeleteSport(int id)
        {
            try
            {
                _logger.LogInformation("entered into delete sport method");
                var sport = sportsRepository.DeleteSport(id);
                return Ok(sport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting sport with ID: {id}.");
                return BadRequest(ex.Message);
            }
        }

        
        
        
        
        
        //save sport by stadium id
        [HttpPost("savesportbystadiumid")]
        public IActionResult SaveSportByStadiumId(int stadiumId, [FromBody] Sports sport)
        {
            try
            {
                _logger.LogInformation("entered into save sport by stadium id");
                var savedSport = sportsRepository.SaveSportByStadiumId(stadiumId, sport);
                return Ok(savedSport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving sport by stadium ID.");
                return BadRequest(ex.Message);
            }
        }

        
        
        
        
        //update sport
        [HttpPut("updatesport")]
        public IActionResult UpdateSport(Sports sport, int id)
        {
            try
            {
                _logger.LogInformation("entered into update sport method");
                var updatedSport = sportsRepository.UpdateSport(sport, id);
                return Ok(updatedSport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating sport with ID: {id}.");
                return BadRequest(ex.Message);
            }
        }
    }
}
