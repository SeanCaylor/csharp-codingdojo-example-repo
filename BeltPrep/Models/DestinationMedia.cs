using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeltPrep.Models
{
    public class DestinationMedia
    {
        [Key]
        public int DestinationMediaId { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "is required.")]
        [Display(Name = "Media Url")]
        public string Src { get; set; }

        [Required(ErrorMessage = "is required.")]
        [Display(Name = "Short Description")]
        [MinLength(4, ErrorMessage = "must be at least 4 characters.")]
        [MaxLength(255, ErrorMessage = "must be no more than 255 characters.")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "is required.")]
        public string Type { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /**********************************************************************
        Foreign Keys and Navigation Properties for Relationships

        Navigation properties are null unless you use .Include / .ThenInclude
        */

        public int UserId { get; set; } // 1 User : Many created Destinations.
        public User CreatedBy { get; set; }

        // Many : Many - 1 Trip can have many Destinations. 1 Destination can be part of many Trips.
        public List<TripDestination> TripDestinations { get; set; }
    }
}