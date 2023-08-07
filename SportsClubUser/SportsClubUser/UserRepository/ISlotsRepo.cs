namespace SportClubProject.UserRepository
{
    public interface ISlotsRepo
    {
        public List<string> GetSlots(string SportName, string date, string CourtName);
    }
}
