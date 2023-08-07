using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using SportClubProject.Repository;
using SportsTime365.Authentication.DTO;
using SportsTime365.Authentication.Services;

namespace SportsTime365.Authentication.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthController> _logger; // Add ILogger

        public AuthController(IUserRepository userRepository, ITokenService tokenService, ILogger<AuthController> logger)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _logger = logger; // Inject ILogger
        }

       
        
        
        
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto model)
        {
            try
            {
                // Implement user registration logic
                // Validate the model, create a new user, and save it using the user repository
                // Validate the model
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Check if the user already exists
                var existingUser = _userRepository.GetUserByEmail(model.Email);
                if (existingUser != null)
                {
                    return BadRequest("User with this email already exists");
                }

                // Create a new User object
                var newUser = new UserDetails
                {
                    UserName = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    Role = "user", // Removed unnecessary assignment here
                    Gender = model.Gender,
                    UserMobile = model.UserMobile,
                    UserAge = model.UserAge
                };

                // Save the new user using the user repository
                _userRepository.CreateUser(newUser);

                return Ok(newUser);
            }
            catch (System.Exception ex) // Catch all exceptions
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred during user registration.");
                return StatusCode(500, "An error occurred during user registration.");
            }
        }

        
        
        
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto model)
        {
            // Implement user login logic
            // Validate the model, authenticate the user, and generate a JWT token using the token service

            // Authenticate the user
            var authenticatedUser = _userRepository.AuthenticateUser(model.Email, model.Password);

            var token = _tokenService.GenerateToken(authenticatedUser.Email, authenticatedUser.Role);

            return Ok(new { Token = token });
        }

        
        
        
        [HttpGet("userData")]
        [Authorize]
        public string LogoutGetAllDetails()
        {
            return "ok";
        }
    }
}
