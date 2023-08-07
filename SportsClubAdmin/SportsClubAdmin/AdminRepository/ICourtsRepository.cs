using Models;

namespace SportClubProject.AdminRepository
{
    public interface ICourtsRepository
    {


        public IEnumerable<Courts> GetAllCourts();

        //delete sport by id

        public Courts DeleteCourt(int id);

        //update sport 

        public Courts UpdateCourt(Courts court,int id);

        //save sport
        public Courts SaveCourt(Courts court);

        //get court by sport id
        public List<Courts> getCourtBySportId(int sportId);

        //save court by sportid
        public Courts SaveCourtBySportId(int sportId, Courts courts);
    }
}
