using AutoMapper;
using Projeect_ITStep.Models;
namespace Projeect_ITStep.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookDto>();
            CreateMap<Author, AuthorDto>();
            CreateMap<Admin, AdminDto>();

            CreateMap<BookDto, Book>();
            CreateMap<AuthorDto, Author>();
            CreateMap<AdminDto, Admin>();
        }
    }
}
