
using Microsoft.AspNetCore.Mvc;
using SportClubProject.UserRepository;

namespace SportClubProject.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotsController : ControllerBase
    {
        private readonly ISlotsRepo slotsRepository;
        private readonly ILogger<SlotsController> _logger;

        public SlotsController(ISlotsRepo slotsRepository, ILogger<SlotsController> logger)
        {
            this.slotsRepository = slotsRepository;
            _logger = logger;
        }

        
        
        // getting all slots from repository
        [HttpGet("getslots")]
        public ActionResult<List<string>> GetAllSlots(string SportName, string Date, string CourtName)
        {
            try
            {
                _logger.LogInformation("entered into get all slots method in slots controller");
                return slotsRepository.GetSlots(SportName, Date, CourtName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting slots for Sport: {SportName}, Date: {Date}, Court: {CourtName}.");
                throw;
            }
        }
    }
}
