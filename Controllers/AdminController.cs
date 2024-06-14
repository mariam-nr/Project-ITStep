using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeect_ITStep.Interfaces;
using Projeect_ITStep.Models;

namespace Projeect_ITStep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public AdminController(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }


        [HttpPost("AddAuthor"), Authorize(Roles = "Admin")]
        public IActionResult AddAuthor([FromBody] AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _adminRepository.AddAuthor(author);
            return Ok("author added successfully");
        }



        [HttpPut("UpdateAuthor"), Authorize(Roles = "Admin")]
        public IActionResult UpdateAuthor(int authorId, [FromBody] AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            var authorUpdated = _adminRepository.UpdateAuthor(authorId, author);
            if (!authorUpdated)
            {
                return BadRequest("author update failed");
            }
            return Ok("author updated");
        }




        [HttpPost("AddBook"), Authorize(Roles = "Admin")]
        public IActionResult AddBook([FromBody] BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            var bookAdded = _adminRepository.AddBook(book);
            if (!bookAdded)
            {
                return BadRequest("invalid author ID");
            }
            return Ok("book added successfully");
        }

        [HttpPut("UpdateBook"), Authorize(Roles = "Admin")]
        public IActionResult UpdateBook(int bookId, [FromBody] BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            var bookUpdated = _adminRepository.UpdateBook(bookId, book);
            if (!bookUpdated)
            {
                return BadRequest("book update failed");
            }
            return Ok("Book updated");
        }

        [HttpDelete("DeleteBook"), Authorize(Roles = "Admin")]
        public IActionResult DeleteBook(int bookId)
        {
            var bookDeleted = _adminRepository.DeleteBook(bookId);
            if (!bookDeleted)
            {
                return BadRequest("book delete failed");
            }
            return Ok("book deleted");
        }

    }
}
