using Microsoft.AspNetCore.Mvc;
using Projeect_ITStep.Interfaces;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Projeect_ITStep.Models;

namespace Projeect_ITStep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllAuthors")]
        public IActionResult GetAllAuthors()
        {
            var authors = _mapper.Map<List<AuthorDto>>(_authorRepository.GetAllAuthors());
            return Ok(authors);
        }

        [HttpGet("GetAuthorById")]
        public IActionResult GetAuthorById(int authorId)
        {
            var author = _mapper.Map<AuthorDto>(_authorRepository.GetAuthorById(authorId));
            if (author == null)
            {
                return BadRequest("Author not found");
            }
            return Ok(author);
        }
    }
}
