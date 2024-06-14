using Projeect_ITStep.Data;
using Projeect_ITStep.Interfaces;
using Projeect_ITStep.Models;

namespace Projeect_ITStep.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private BooksDbContext _dbContext;
        public AdminRepository(BooksDbContext booksDbContext)
        {
            _dbContext = booksDbContext;
        }

        public void AddAuthor(Author author)
        {
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
        }

        public bool AddBook(Book book)
        {
            var author = _dbContext.Authors.FirstOrDefault(x => x.ID == book.AuthorId);
            if (author == null)
            {
                return false;
            }

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            return true;
        }


        public bool DeleteBook(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return false;
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateAuthor(int authorId, Author author)
        {
            var oldAuthor = _dbContext.Authors.FirstOrDefault(x => x.ID == authorId);
            if (oldAuthor == null)
            {
                return false;
            }
            oldAuthor.Name = author.Name;
            oldAuthor.Email = author.Email;
            _dbContext.Authors.Update(oldAuthor);
            _dbContext.SaveChanges();
            return true;

        }

        public bool UpdateBook(int id, Book book)
        {
            var oldBook = _dbContext.Books.FirstOrDefault(x => x.Id == id);
            var author = _dbContext.Authors.FirstOrDefault(x => x.ID == book.AuthorId);

            if (oldBook == null || book == null)
            {
                return false;
            }
            oldBook.Title = book.Title;
            oldBook.Description = book.Description;
            oldBook.BookAuthor = book.BookAuthor;
            oldBook.ReleseYear = book.ReleseYear;

            _dbContext.Books.Update(oldBook);
            _dbContext.SaveChanges();

            return true;
        }
    }

}
