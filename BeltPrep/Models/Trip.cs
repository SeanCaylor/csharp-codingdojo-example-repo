using System;
using System.ComponentModel.DataAnnotations;

namespace BeltPrep.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "must be at least 2 characters.")]
        public string Name { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "must be at least 4 characters.")]
        [MaxLength(255, ErrorMessage = "must be no more than 255 characters.")]
        public string Description { get; set; }

        [Display(Name = "Trip Date")]
        [DataType(DataType.Date)]
        // TODO: Future Date validation
        public DateTime Date { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* 
        Foreign Keys and Navigation Properties for Relationships

        Navigation properties are null unless you use .Include / .ThenInclude
        */
    }
}