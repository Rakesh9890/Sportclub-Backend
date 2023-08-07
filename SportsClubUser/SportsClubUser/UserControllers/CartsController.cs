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
    public class CartsController : ControllerBase
    {
        private readonly ICartsRepo CartsRepository;
        private readonly ILogger<CartsController> _logger;

        public CartsController(ICartsRepo cartsRepository, ILogger<CartsController> logger)
        {
            CartsRepository = cartsRepository;
            _logger = logger;
        }

      
        
        
        // get all carts
        [HttpGet("getcarts")]
        public ActionResult<List<Cart>> GetAllCarts(int userId)
        {
            try
            {
                _logger.LogInformation("entered into get carts method in carts controller");
                return CartsRepository.GetAllCarts(userId).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting carts for user with ID: {userId}.");
                throw;
            }
        }

       
        
        
        
        // save cart
        [HttpPost("saveallcarts")]
        public IActionResult SaveCarts(Cart cart)
        {
            try
            {
                _logger.LogInformation("entered into save carts method in carts controller");
                var result = CartsRepository.SaveCart(cart);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving cart.");
                return BadRequest(ex.Message);
            }
        }

        
        
        
        // delete cart
        [HttpDelete("deletecart")]
        public IActionResult DeleteCart(int userId, int cartId)
        {
            try
            {
                _logger.LogInformation("entered into delete cart method in cart controller");
                var result = CartsRepository.DeleteCart(userId, cartId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting cart with ID: {cartId} for user with ID: {userId}.");
                return BadRequest(ex.Message);
            }
        }
    }
}
