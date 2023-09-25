using Org.BouncyCastle.Bcpg.OpenPgp;
using System.ComponentModel.DataAnnotations;

namespace BlogV_005.ViewModels
{
    public class ContactMe
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be between {2} and {1} characters long", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "The {0} must be between {2} and {1} characters long", MinimumLength = 2)]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long", MinimumLength = 2)]
        public string Subject { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be between {2} and {1} characters long", MinimumLength = 2)]
        public string Message { get; set; }
    }
}
