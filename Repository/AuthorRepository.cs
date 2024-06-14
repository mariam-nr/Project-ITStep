using Projeect_ITStep.Data;
using Projeect_ITStep.Interfaces;
using Projeect_ITStep.Models;

namespace Projeect_ITStep.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BooksDbContext _booksDbContext;

        public AuthorRepository(BooksDbContext booksDbContext)
        {
            _booksDbContext = booksDbContext;
        }
        public ICollection<Author> GetAllAuthors()
        {
            var authors = _booksDbContext.Authors.ToList();
            return authors;
        }

        public Author GetAuthorById(int id)
        {
            var author = _booksDbContext.Authors.FirstOrDefault(x => x.ID == id);
            return author;
        }
    }
}
