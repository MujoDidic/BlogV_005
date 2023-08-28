using System.ComponentModel.DataAnnotations;

namespace BlogV_005.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public int? PostId { get; set; }
        public string? BlogUserId { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be between {2} and {1} characters long", MinimumLength = 3)]
        public string Text { get; set; }

        //Navigation properties
        public virtual Post? Post { get; set; } //LP
        public virtual BlogUser? BlogUser { get; set; } //LP
    }
}
