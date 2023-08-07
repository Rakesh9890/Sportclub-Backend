


using Models;

namespace SportClubProject.Repository
{
    public interface IUserRepository
    {
        public UserDetails SaveUserDeatails(UserDetails userDetails);

        public UserDetails GetUserByEmail(string email);
        UserDetails AuthenticateUser(string Emial, string password);

        UserDetails CreateUser(UserDetails user);
    }
}
