using Projeect_ITStep.Models;

namespace Projeect_ITStep.Interfaces
{
    public interface IAuthorRepository
    {
        public ICollection<Author> GetAllAuthors();
        public Author GetAuthorById(int id);

    }
}
