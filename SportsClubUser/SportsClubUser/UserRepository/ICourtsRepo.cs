using Models;

namespace SportClubProject.UserRepository
{
    public interface ICourtsRepo
    {
        public List<Courts> GetAllCourts(string SportName, string date);
    }
}
