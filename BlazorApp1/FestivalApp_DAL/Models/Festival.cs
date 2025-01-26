using System;
using System.ComponentModel.DataAnnotations;

namespace FestivalApp_DAL.Models
{
    public class Festival
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int ArtistId { get; set; } // Foreign Key to Artist
        
        [Required]
        public string FestivalName { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        public string Time { get; set; }
        
        [Required]
        public double TicketCost { get; set; }
    }
}