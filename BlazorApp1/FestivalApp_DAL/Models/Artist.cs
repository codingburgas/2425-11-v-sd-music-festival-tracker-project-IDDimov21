namespace FestivalApp_DAL.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public float Rating { get; set; } = 0; // Default Rating is 0
    }
}