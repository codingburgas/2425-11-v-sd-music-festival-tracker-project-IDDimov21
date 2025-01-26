using System.ComponentModel.DataAnnotations;

namespace FestivalApp_DAL.Models
{
    public class Guest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(10)]
        public string Role { get; set; } = "Guest"; // ✅ Add Role Property
    }
}