using Models;

namespace SportClubProject.UserRepository
{
    public interface ICartsRepo
    {

        public List<Cart> GetAllCarts(int userId);
        public string SaveCart(Cart carts);
        public string DeleteCart(int userId,int cartId);
    }
}
