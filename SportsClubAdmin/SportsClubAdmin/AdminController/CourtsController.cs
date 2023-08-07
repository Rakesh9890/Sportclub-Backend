using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportClubProject.AdminRepository;
using Models;


namespace SportClubProject.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtsController : ControllerBase
    {
        private readonly ICourtsRepository courtsRepository;
        private readonly ILogger<CourtsController> _logger; // Add ILogger

        public CourtsController(ICourtsRepository courtsRepository, ILogger<CourtsController> logger)
        {
            this.courtsRepository = courtsRepository;
            _logger = logger; // Inject ILogger
        }

        
        //get all courts
        [HttpGet("getallcourts")]
        public IEnumerable<Courts> GetAllCourts()
        {
            try
            {
                _logger.LogInformation("entered get all courts method");
                IEnumerable<Courts> courts = courtsRepository.GetAllCourts().ToList();
                return courts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all courts.");
                throw;
            }
        }

       
        
        //get court by sport id
        [HttpGet("getcourtbysportid")]
        public IEnumerable<Courts> GetCourtBySportId(int sportId)
        {
            try
            {
                _logger.LogInformation("entered get court by sport id method");
                IEnumerable<Courts> courts = courtsRepository.getCourtBySportId(sportId);
                return courts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting courts for sport ID: {sportId}.");
                throw;
            }
        }

        
        //saving court
        [HttpPost("savecourt")]
        public IActionResult SaveCourt(Courts court)
        {
            try
            {
                _logger.LogInformation("entered into save court method");
                Courts savedCourt = courtsRepository.SaveCourt(court);
                return Ok(savedCourt);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving court.");
                return BadRequest(ex.Message);
            }
        }

        
        //save court by sport id
        [HttpPost("savecourtbysportid")]
        public IActionResult SaveCourtBySportId(int sportId, [FromBody] Courts court)
        {
            try
            {
                _logger.LogInformation("entered into save court by sport id method");
                var savedCourt = courtsRepository.SaveCourtBySportId(sportId, court);
                return Ok(savedCourt);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving court by sport ID.");
                return BadRequest(ex.Message);
            }
        }

        
        //delete court
        [HttpDelete("deletecourt")]
        public IActionResult DeleteCourt(int id)
        {
            try
            {
                _logger.LogInformation("entered into delete court method");
                var court = courtsRepository.DeleteCourt(id);
                return Ok(court);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting court with ID: {id}.");
                return BadRequest(ex.Message);
            }
        }

        
        //update court
        [HttpPut("updatecourt")]
        public IActionResult UpdateCourt(Courts court, int id)
        {
            try
            {
                _logger.LogInformation("entered into update court method");
                var updatedCourt = courtsRepository.UpdateCourt(court, id);
                return Ok(updatedCourt);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating court with ID: {id}.");
                return BadRequest(ex.Message);
            }
        }
    }
}
