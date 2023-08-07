namespace SportsTime365.Authentication.DTO
{
    public class RegisterDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int UserAge { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public long UserMobile { get; set; }
    }
}
