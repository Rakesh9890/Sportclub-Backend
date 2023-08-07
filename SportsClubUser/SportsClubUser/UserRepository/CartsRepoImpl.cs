using Models;
using SportClubProject.Repository;
using SportClubProject.Services;

namespace SportClubProject.UserRepository
{
    public class CartsRepoImpl : ICartsRepo
    {
        //sports dbcontext
        public readonly SportsDbContext sportsDbContext;

        //logger
        public readonly ILogger<CartsRepoImpl> logger;

        //user service
       
       public readonly UserService userService;

        //injecting sportsdb context ,user service and logger
        public CartsRepoImpl(SportsDbContext sportsDbContext,UserService userService, ILogger<CartsRepoImpl> logger)
        {
            this.sportsDbContext = sportsDbContext;
            this.userService = userService;
            this.logger = logger;
        }


        //delete cart
        public string DeleteCart(int userId, int cartId)
        {
            logger.LogInformation("entered into delete cart method in cart repo implementation");
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Cart cart = sportsDbContext.Carts.FirstOrDefault(i => i.UserId == userId && i.CartId == cartId);

           if(cart != null)
            {
                sportsDbContext.Carts.Remove(cart);
                sportsDbContext.SaveChanges();

                return "successfully deleted";
            }
            else
            {
                return "cart is null";
            }

        }


        //get all carts
        public List<Cart> GetAllCarts(int userId)
        {
            try
            {
                logger.LogInformation("entered into get all carts method in carts repo impl");
                return userService.GetAllCarts(userId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "an error occur while get carts in carts repo impl");
                throw;
            }
        }


        //save cart
        public string SaveCart(Cart carts)
        {

            try
            {
                logger.LogInformation("entered ino save cart method in cart repo impl");
                string result = userService.SaveCart(carts);
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex,"error occur while saving cart in cart repo impl");
                throw;

            }
        }


    }
}
