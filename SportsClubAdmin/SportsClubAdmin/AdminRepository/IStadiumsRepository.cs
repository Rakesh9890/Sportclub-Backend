using Models;

namespace SportClubProject.AdminRepository
{
    public interface IStadiumsRepository
    {

        //get all stadiums
        public IEnumerable<Stadiums>  GetAllStadiums();  


        //save all stadiums
        public Stadiums SaveStadium(Stadiums stadium);


        //delete stadium
        public Stadiums DeleteStadium(int stadiumId);
    }
}
