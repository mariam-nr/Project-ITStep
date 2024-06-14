using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeect_ITStep.Interfaces;
using Projeect_ITStep.Models;

namespace Projeect_ITStep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var books = _mapper.Map<List<BookDto>>(_bookRepository.GetAllBooks());
            return Ok(books);
        }

        [HttpGet("GetBookById")]
        public IActionResult GetBookById(int id)
        {
            var book = _mapper.Map<BookDto>(_bookRepository.GetBookById(id));
            if (book == null)
            {
                return BadRequest("Book not found");
            }
            return Ok(book);
        }

        [HttpGet("GetBooksByTitle")]
        public IActionResult GetBooksByTitle (string title)
        {
            var books = _mapper.Map<List<BookDto>>(_bookRepository.GetBooksByTitle(title));
            if (books == null)
            {
                return BadRequest("Books not found");
            }
            return Ok(books);
        }

        [HttpGet("GetBooksByAuthor")]
        public IActionResult GetBooksByAuthor(int authorId)
        {
            var books = _mapper.Map<List<BookDto>>(_bookRepository.GetBooksByAuthor(authorId));
            if (books == null)
            {
                return BadRequest("Books not found");
            }
            return Ok(books);
        }
    }
}
