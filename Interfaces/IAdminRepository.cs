using Projeect_ITStep.Models;

namespace Projeect_ITStep.Interfaces
{
    public interface IAdminRepository
    {
        public bool AddBook(Book book);
        public bool UpdateBook(int id, Book book);
        public bool DeleteBook(int id);
        public void AddAuthor (Author author);
        public bool UpdateAuthor (int authorId, Author author);
    }
}
