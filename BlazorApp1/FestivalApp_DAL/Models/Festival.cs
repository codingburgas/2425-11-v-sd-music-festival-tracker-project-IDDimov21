using System;
using System.ComponentModel.DataAnnotations;

namespace FestivalApp_DAL.Models
{
    public class Festival
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FestivalName { get; set; }

        [Required]
        public int ArtistId { get; set; } // Foreign Key to Artist

        [Required]
        public DateTime Date { get; set; }  // Store as text in SQLite

        [Required]
        public string Time { get; set; }  // Store as "HH:mm"

        [Required]
        public double TicketCost { get; set; }
    }
}