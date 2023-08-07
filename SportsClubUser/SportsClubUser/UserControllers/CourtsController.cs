using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using SportClubProject.Repository;
using SportClubProject.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportClubProject.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtsController : ControllerBase
    {
        private readonly ICourtsRepo CourtsRepository;
        private readonly ILogger<CourtsController> _logger;

        public CourtsController(ICourtsRepo courtsRepository, ILogger<CourtsController> logger)
        {
            CourtsRepository = courtsRepository;
            _logger = logger;
        }




        // get all courts from repository
        [HttpGet("getcourts")]
        public ActionResult<List<Courts>> GetAllCourts(string SportName, string Date)
        {
            try
            {
                _logger.LogInformation("entered into get all courts method in courts controller");

                return CourtsRepository.GetAllCourts(SportName, Date).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting courts for Sport: {SportName} on Date: {Date}.");
                throw;
            }
        }
    }
}
