using BlogV_005.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogV_005.Models
{
    public class Post
    {
        [Key]
        public int? Id { get; set; }
        [ForeignKey("Blog")]
        public int? BlogId { get; set; }
        [ForeignKey("Author")]
        public string? BlogUserId { get; set; }

        [Required]
        [StringLength(75, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(75, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string Abstract { get; set; }

        [Required]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated")]
        public DateTime Updated { get; set; }

        public ReadyStatus ReadyStatus { get; set; }

        public string Slug { get; set; }

        [Display(Name = "Post Image")]
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        public virtual Blog? Blog { get; set; }
        public virtual BlogUser? BlogUser { get; set; }

        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();



    }
}
