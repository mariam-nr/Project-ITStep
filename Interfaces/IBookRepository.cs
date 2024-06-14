using Projeect_ITStep.Models;

namespace Projeect_ITStep.Interfaces
{
    public interface IBookRepository
    {
        public ICollection<Book> GetAllBooks();
        public Book GetBookById(int id);
        public ICollection<Book> GetBooksByTitle(string name);
        public ICollection<Book> GetBooksByAuthor(int authorId);
    }
}
