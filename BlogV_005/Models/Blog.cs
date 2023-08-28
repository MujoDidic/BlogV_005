using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogV_005.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Author")]
        [ForeignKey("Author")]
        public string? AuthorId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Created")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated")]
        public DateTime Updated { get; set; }

        [Display(Name = "Blog photo")]
        public byte[]? ImageData { get; set; }
        public string? ContentData { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

        //Navigation properties

        public virtual BlogUser? Author { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();




    }
}
