using Models;

namespace SportClubProject.AdminRepository
{
    public interface ISlotsRepository
    {

        //get all slots
        public IEnumerable<Slots> GetAllSlots();


        //get slot by id

        public Slots GetSlot(int id);

        //delete slot by id

        public Slots DeleteSlot(int id);

        //update slot 

        public Slots UpdateSlot(Slots slot, int id);

        //save slot
        public Slots SaveSlot(Slots slot);
    }
}
