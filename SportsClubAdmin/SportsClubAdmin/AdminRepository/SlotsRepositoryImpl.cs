
using Models;
using SportClubProject.Repository;

namespace SportClubProject.AdminRepository
{
    public class SlotsRepositoryImpl : ISlotsRepository

    {
        //sports db context
        private readonly SportsDbContext sportsDbContext;

        //logger
        private readonly ILogger<SlotsRepositoryImpl> logger;

        //injecting sportsdbcontext and logger
        public SlotsRepositoryImpl(SportsDbContext sportsDbContext,ILogger<SlotsRepositoryImpl> logger)
        {
            this.logger = logger;
            this.sportsDbContext = sportsDbContext;
        }

        
        //get all slots
        public IEnumerable<Slots> GetAllSlots()
        {
            try
            {
                logger.LogInformation("entered into get all slots method in slots repository impl");
                return sportsDbContext.Slots.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error occur while get all slots in slot repository impl");
                throw;
            }
        }


        //get slot by id
        public Slots GetSlot(int id)
        {
            try
            {
                logger.LogInformation("entered into get  slots method in slots repository impl");
                return sportsDbContext.Slots.Find(id);
            }
            catch (Exception ex) {
                logger.LogError(ex,"error occur while getting slot in slot repository impl");
                throw;
            }

        }


        //save slot
        public Slots SaveSlot(Slots slot)
        {
            try
            {
                logger.LogInformation("entered into save slots method in slots repository impl");
                sportsDbContext.Slots.Add(slot);
                sportsDbContext.SaveChanges();
                return slot;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "error occur while save slots in slot repository impl");
                throw;
            }

        }


        //delete slot
        public Slots DeleteSlot(int id)
        {
            try
            {
                Slots slot = sportsDbContext.Slots.Find(id);
                if (slot != null)
                {
                    sportsDbContext.Slots.Remove(slot);
                    sportsDbContext.SaveChanges();
                }
                return slot;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while deleting slot with ID {SlotId}", id);
                throw; 
            }
        }


        //update slot
        public Slots UpdateSlot(Slots slot, int id)
        {
            try
            {
                var existingSlot = sportsDbContext.Slots.FirstOrDefault(s => s.SlotId == id);
                if (existingSlot != null)
                {
                    existingSlot.SlotTime = slot.SlotTime;
                    existingSlot.Day = slot.Day;

                    sportsDbContext.SaveChanges();
                }
                return existingSlot;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while updating slot with ID {SlotId}", id);
                throw;
            }
        }

    }

       
      
}

