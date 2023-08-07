
using Microsoft.AspNetCore.Mvc;
using Models;
using SportClubProject.AdminRepository;

namespace SportClubProject.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private readonly IStadiumsRepository stadiumsRepository;
        private readonly ILogger<StadiumController> _logger; // Add ILogger

        public StadiumController(IStadiumsRepository stadiumsRepository, ILogger<StadiumController> logger)
        {
            this.stadiumsRepository = stadiumsRepository;
            _logger = logger; // Inject ILogger
        }

        
        
        
        //get all stadiums
        [HttpGet("getallstadiums")]
        public IEnumerable<Stadiums> GetAllStadiums()
        {
            try
            {
                _logger.LogInformation("entered into get all stadiums method");
                IEnumerable<Stadiums> stadiums = stadiumsRepository.GetAllStadiums().ToList();
                return stadiums;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all stadiums.");
                throw;
            }
        }

       
        
        
        //save stadium
        [HttpPost("savestadium")]
        public IActionResult SaveStadium(Stadiums stadium)
        {
            try
            {
                _logger.LogInformation("entered into save stadium method");
                Stadiums savedStadium = stadiumsRepository.SaveStadium(stadium);
                return Ok(savedStadium);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving stadium.");
                return BadRequest(ex.Message);
            }
        }

        
        
        
        //delete stadium
        [HttpDelete("deletestadium")]
        public IActionResult DeleteStadium(int stadiumId)
        {
            try
            {
                _logger.LogInformation("entered into delete stadium method ");
                var stadium = stadiumsRepository.DeleteStadium(stadiumId);
                return Ok(stadium);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting stadium with ID: {stadiumId}.");
                return BadRequest(ex.Message);
            }
        }
    }
}
