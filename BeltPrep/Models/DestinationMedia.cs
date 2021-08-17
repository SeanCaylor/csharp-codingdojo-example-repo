using System;
using System.ComponentModel.DataAnnotations;

namespace BeltPrep.Models
{
    public class DestinationMedia
    {
        [Key]
        public int DestinationMediaId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "must be at least 2 characters.")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Url")]
        public string Src { get; set; }

        [Required]
        [Display(Name = "Short Description")]
        [MinLength(4, ErrorMessage = "must be at least 4 characters.")]
        [MaxLength(255, ErrorMessage = "must be no more than 255 characters.")]
        public string ShortDescription { get; set; }

        [Required]
        public string Type { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* 
        Foreign Keys and Navigation Properties for Relationships

        Navigation properties are null unless you use .Include / .ThenInclude
        */
    }
}