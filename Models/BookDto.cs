using System.ComponentModel.DataAnnotations;

namespace Projeect_ITStep.Models
{
    public class BookDto
    {
        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
    }
}
