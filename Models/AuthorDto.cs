using System.ComponentModel.DataAnnotations;

namespace Projeect_ITStep.Models
{
    public class AuthorDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
