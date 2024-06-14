using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeect_ITStep.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int AuthorId { get; set; }
        public Author BookAuthor { get; set; }
        //[ForeignKey("Author")]
        //public int AuthorId { get; set; }
        public int ReleseYear { get; set; }

    }
}
