using System;
using System.ComponentModel.DataAnnotations;

namespace EasyTicket_Pro.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [MaxLength(100)]
        public string Location { get; set; } = string.Empty;
    }
}