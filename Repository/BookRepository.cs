using Projeect_ITStep.Data;
using Projeect_ITStep.Interfaces;
using Projeect_ITStep.Models;

namespace Projeect_ITStep.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksDbContext _booksDbContext;

        public BookRepository(BooksDbContext booksDbContext)
        {
            _booksDbContext = booksDbContext;
        }
        public ICollection<Book> GetAllBooks()
        {
            var books = _booksDbContext.Books.ToList();
            return books;
        }

        public ICollection<Book> GetBooksByAuthor(int authorId)
        {
            var books = _booksDbContext.Books.Where(i=>i.AuthorId == authorId).ToList();
            return books;
        }

        public Book GetBookById(int id)
        {
            var book = _booksDbContext.Books.FirstOrDefault(i=>i.Id == id);
            return book;
        }

        public ICollection<Book> GetBooksByTitle(string title)
        {
            var books = _booksDbContext.Books.Where(i=>i.Title == title).ToList();
            return books;
        }
    }
}
