using System;
using System.ComponentModel.DataAnnotations;

namespace FestivalApp_DAL.Models
{
    public class Festival
    {
        public int Id { get; set; }
        public string FestivalName { get; set; }
        public DateTime Date { get; set; }  // ✅ Ensure this is DateTime
        public string Time { get; set; } // Store time as a string
        public double TicketCost { get; set; }
    }



}