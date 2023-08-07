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
    public class CouponsController : ControllerBase
    {
        private readonly ICouponsRepo couponsRepository;
        private readonly ILogger<CouponsController> _logger;

        public CouponsController(ICouponsRepo couponsRepository, ILogger<CouponsController> logger)
        {
            this.couponsRepository = couponsRepository;
            _logger = logger;
        }

       
        
        //get coupons
        
        [HttpGet("getcoupons")]
        public ActionResult<IEnumerable<Coupons>> GetAllCoupons()
        {
            try
            {
                _logger.LogInformation("entered into get all coupons method in coupons controller");
                return couponsRepository.GetAllCoupons().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all coupons.");
                throw;
            }
        }
    }
}
