using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogV_005.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Post")]
        public int? PostId { get; set; }
        [ForeignKey("Author")]
        public string? AuthorId { get; set; }
        public string? ModeratorId { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be between {2} and {1} characters long.")]
        [Display(Name = "Comment")]
        public string Body { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created")]
        public DateTime Updated { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Moderated")]
        public DateTime Moderated { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Deleted")]
        public DateTime Deleted { get; set; }

        [StringLength(500, ErrorMessage = "The {0} must be between {2} and {1} characters long.")]
        public string? ModeratedBody { get; set; }


        //Navigation properties

        public virtual Post? Post { get; set; }
        public virtual BlogUser? Author { get; set; }
        public virtual BlogUser? Moderator { get; set; }





    }
}
