using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeltPrep.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(10, ErrorMessage = "must be at least 10 characters.")]
        public string Description { get; set; }

        [Display(Name = "Trip Date")]
        [DataType(DataType.Date)]
        // TODO: Future Date validation
        public DateTime? Date { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /**********************************************************************
        Foreign Keys and Navigation Properties for Relationships

        Navigation properties are null unless you use .Include / .ThenInclude
        */
        public int UserId { get; set; } // 1 User : Many created trips.
        public User CreatedBy { get; set; }

        // Many to Many: 1 User likes Many Trips, 1 Trip liked by Many Users
        public List<UserTripLike> Likes { get; set; }

        // Many : Many - 1 Trip can have many Destinations. 1 Destination can be part of many Trips.
        public List<TripDestination> TripDestinations { get; set; }
    }
}