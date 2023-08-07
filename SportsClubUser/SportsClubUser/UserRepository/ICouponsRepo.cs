using Models;

namespace SportClubProject.UserRepository
{
    public interface ICouponsRepo
    {
        public IEnumerable<Coupons> GetAllCoupons();
    }
}
