

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
        public  readonly ILogger<UserRepositoryImpl> logger;

        // Constructor injection with both dependencies
        public UserRepositoryImpl(SportsDbContext sportsDbContext,UserService userService,ILogger<UserRepositoryImpl> logger)
        {
             this.userService = userService;
            this.sportsDbContext = sportsDbContext;
            this.logger = logger;
        }


       //save user details
        public UserDetails SaveUserDeatails(UserDetails userDetails)
        {
            try
            {
                logger.LogInformation("entered into save user details method in user repository impl");
                userService.Savedetails(userDetails);
                return userDetails;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error occur while save user details in user repository impl");
                throw;
            }
        }


        //authenticating user
        public UserDetails AuthenticateUser(string Emial, string password)
        {
            try
            {
                logger.LogInformation("entered into authenticate user method in user reo impl");
                var user = sportsDbContext.UserDetails.SingleOrDefault(u => u.Email == Emial && u.Password == password);
                return user;
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "error occur while authenticating user in user repo impl");
                throw;
            }
        }


        //save user
        public UserDetails CreateUser(UserDetails user)
        {
            try
            {
                logger.LogInformation("entered into create user method in user repo impl");
                sportsDbContext.UserDetails.Add(user);
                sportsDbContext.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error occur while creating user in user repo impl");
                throw;
            }
        }


        //get user by email
        public UserDetails GetUserByEmail(string email)
        {
            try
            {
                logger.LogInformation("entered into get user by email in user repo impl");
                return sportsDbContext.UserDetails.FirstOrDefault(u => u.Email == email);
            }
            catch (Exception ex)
            {
                logger.LogError(ex,"error occur while get user by email in user repo impl");
                throw;
            }
        }
    }
}
