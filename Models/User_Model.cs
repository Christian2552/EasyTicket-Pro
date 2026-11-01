//  using System.ComponentModel.DataAnnotations; is for data validation attributes in the User model class.
using System.ComponentModel.DataAnnotations;

namespace EasyTicket_Pro.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 15 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 15 characters.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}