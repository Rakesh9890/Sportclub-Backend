using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using SportClubProject.UserRepository;
using System;
using System.Collections.Generic;

namespace SportClubProject.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        public ISportsRepo SportsRepository { get; set; }
        private readonly ILogger<SportsController> _logger;


        //injecting sportsrepository ang logger
        public SportsController(ISportsRepo sportsRepository, ILogger<SportsController> logger)
        {
            _logger = logger;
            SportsRepository = sportsRepository;
        }

       
        
        // Getting sports from repository
        [HttpGet("getsports")]
        public ActionResult<IEnumerable<Sports>> GetAllSports()
        {
            try
            {
                _logger.LogInformation("entered into get all sports method in sports controller ");
                return SportsRepository.GetAllSports().ToList();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex,"error occured while getting sports");
                throw; 
            }
        }

       
    }
}
