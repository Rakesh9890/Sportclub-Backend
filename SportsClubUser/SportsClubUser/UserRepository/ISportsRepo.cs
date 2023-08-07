using Models;

namespace SportClubProject.UserRepository
{
    public interface ISportsRepo
    {
        public IEnumerable<Sports> GetAllSports();


        //get sport by stadiumid

    //    public List<Sports> GetSportByStadiumId(int stadiumId);
    }
}
