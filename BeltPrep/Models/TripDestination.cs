using System;
using System.ComponentModel.DataAnnotations;

namespace BeltPrep.Models
{
    // Many to Many 'through' / 'join' table. 
    // 1 Trip can have many Destinations, 1 Destination be part of Many Trips
    public class TripDestination
    {
        [Key]
        public int TripDestinationId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /**********************************************************************
        Foreign Keys and Navigation Properties for Relationships

        Navigation properties are null unless you use .Include / .ThenInclude
        */
        public int DestinationMediaId { get; set; } // FK
        public DestinationMedia DestinationMedia { get; set; }
        public int TripId { get; set; } // FK
        public Trip Trip { get; set; }

    }
}