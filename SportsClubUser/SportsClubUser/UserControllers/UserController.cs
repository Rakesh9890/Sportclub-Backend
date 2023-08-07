using Microsoft.AspNetCore.Mvc;
using Models;
using SportClubProject.Repository;
using System;

namespace SportClubProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // User repository implementation
        private readonly IUserRepository userRepository;
        private readonly ILogger<UserController> _logger;

        // Injecting user repository implementation
        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            this.userRepository = userRepository;
            _logger = logger;
        }


        //save user
        [HttpPost("saveuser")]
        public UserDetails SaveUser(UserDetails user)
        {
            try
            {
                _logger.LogInformation("entered into save user method in user controller");
                return userRepository.SaveUserDeatails(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"An error occurred while saving user details");
                throw; 
            }
        }

        
        
        //get user

        [HttpGet("getuser")]
        public UserDetails GetUser(string email)
        {
            try
            {
                _logger.LogInformation("entered into get user method in user controller");
                return userRepository.GetUserByEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"An error occurred while getting user details");
                throw; 
            }
        }
    }
}
