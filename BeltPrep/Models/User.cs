using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltPrep.Models
{
    public class User
    {
        [Key] // denotes PK, not needed if named ModelNameId
        public int UserId { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(8, ErrorMessage = "must be at least 8 characters")]
        [DataType(DataType.Password)] // auto fills input type attr
        public string Password { get; set; }

        [NotMapped] // don't add to DB
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "doesn't match password")]
        [Display(Name = "Confirm Password")]
        public string PasswordConfirm { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /**********************************************************************
        Foreign Keys and Navigation Properties for Relationships

        Navigation properties are null unless you use .Include / .ThenInclude
        */

        public List<Trip> CreatedTrips { get; set; } // 1 User : Many Trip
        public List<DestinationMedia> CreatedDestinations { get; set; } // 1 User : Many DestinationMedia

        // Many to Many: 1 User likes Many Trips, 1 Trip liked by Many Users
        public List<UserTripLike> Likes { get; set; }

        // Methods
        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}