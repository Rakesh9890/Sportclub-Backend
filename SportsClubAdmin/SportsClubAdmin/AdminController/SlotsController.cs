
using Microsoft.AspNetCore.Mvc;
using SportClubProject.AdminRepository;
using Models;


namespace SportClubProject.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotsController : ControllerBase
    {
        private readonly ISlotsRepository slotsRepository;
        private readonly ILogger<SlotsController> _logger; // Add ILogger

        public SlotsController(ISlotsRepository slotsRepository, ILogger<SlotsController> logger)
        {
            this.slotsRepository = slotsRepository;
            _logger = logger; // Inject ILogger
        }

        
        //getting slots
        
        [HttpGet("getallslots")]
        public IEnumerable<Slots> GetAllSlots()
        {
            try
            {
                _logger.LogInformation("entered into get all slots method");
                IEnumerable<Slots> slots = slotsRepository.GetAllSlots().ToList();
                return slots;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all slots.");
                throw;
            }
        }

        
        
        //save slots
        [HttpPost("saveslot")]
        public IActionResult SaveSlot(Slots slot)
        {
            try
            {
                _logger.LogError("entered into save slot method");
                Slots savedSlot = slotsRepository.SaveSlot(slot);
                return Ok(savedSlot);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving slot.");
                return BadRequest(ex.Message);
            }
        }

       
        
        //delete slot
        [HttpDelete("deleteslot")]
        public IActionResult DeleteSlot(int id)
        {
            try
            {
                _logger.LogError("entered into delete slot method");
                var slot = slotsRepository.DeleteSlot(id);
                return Ok(slot);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting slot with ID: {id}.");
                return BadRequest(ex.Message);
            }
        }

        
        
        
        //update slot
        [HttpPut("updateslot")]
        public IActionResult UpdateSlot(Slots slot, int id)
        {
            try
            {
                _logger.LogInformation("entered into update slot method");
                var updatedSlot = slotsRepository.UpdateSlot(slot, id);
                return Ok(updatedSlot);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating slot with ID: {id}.");
                return BadRequest(ex.Message);
            }
        }
    }
}
