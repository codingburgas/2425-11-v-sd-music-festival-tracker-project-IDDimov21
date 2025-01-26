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
        [DataType(DataType.Date)]
        public string Date { get; set; } // Keep as string for JSON handling

        [Required]
        [DataType(DataType.Time)]
        public string Time { get; set; } // Keep as string for JSON handling

        [Required]
        public double TicketCost { get; set; }
    }
}