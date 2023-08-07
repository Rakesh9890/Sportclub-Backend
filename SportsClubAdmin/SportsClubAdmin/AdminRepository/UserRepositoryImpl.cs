

using Microsoft.EntityFrameworkCore;
using Models;
using SportClubProject.Services;

namespace SportClubProject.Repository
{
    public class UserRepositoryImpl : IUserRepository

    {

        //sports dbcontext
        public readonly SportsDbContext sportsDbContext;

        //user service

        public readonly UserService userService;

        //logger
        private readonly ILogger<UserRepositoryImpl> logger;

        // Constructor injection with both dependencies
        public UserRepositoryImpl(UserService userService, SportsDbContext sportsDbContext, ILogger<UserRepositoryImpl> logger)
        {
            this.logger = logger;
            this.userService = userService;
            this.sportsDbContext = sportsDbContext;
        }


       //save user details
        public UserDetails SaveUserDeatails(UserDetails userDetails)
        {
            try
            {
                logger.LogInformation("entered saveuserdetails method in user repository impl");
                userService.Savedetails(userDetails);
                return userDetails;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error occured while saveing user details");
                throw;
            }
        }


        //authenticate user
        public UserDetails AuthenticateUser(string Emial, string password)
        {
            try
            {
                logger.LogInformation("");
                var user = sportsDbContext.UserDetails.SingleOrDefault(u => u.Email == Emial && u.Password == password);
                return user;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "");
                throw;
            }
        }


        //create user
        public UserDetails CreateUser(UserDetails user)
        {
            try
            {
                logger.LogInformation("entered create user method in user repository impl");
                sportsDbContext.UserDetails.Add(user);
                sportsDbContext.SaveChanges();

                return user;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error occur while creating user");
                throw;
            }
        }


        //get user by email
        public UserDetails GetUserByEmail(string email)
        {
            try
            {
                logger.LogInformation("entered into getuser by eamil method in user repository impl");
                return sportsDbContext.UserDetails.FirstOrDefault(u => u.Email == email);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error occured while get user by email");
                throw;
            }
        }
    }
}
