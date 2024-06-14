using System.ComponentModel.DataAnnotations;
namespace Projeect_ITStep.Models
{
    public class Author
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //public List<Book>? Books { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
