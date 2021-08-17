using System;
using System.ComponentModel.DataAnnotations;

namespace BeltPrep.Models
{
    // Many to Many 'through' / 'join' table. 
    // 1 User can like Many trips. 1 Trip can be liked by Many Users.
    public class UserTripLike
    {
        [Key]
        public int UserTripLikeId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /**********************************************************************
        Foreign Keys and Navigation Properties for Relationships

        Navigation properties are null unless you use .Include / .ThenInclude
        */
        public int UserId { get; set; } // FK
        public User User { get; set; }
        public int TripId { get; set; } // FK
        public Trip Trip { get; set; }

    }
}