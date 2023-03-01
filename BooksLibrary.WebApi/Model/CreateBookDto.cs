using AutoMapper;
using BooksLibrary.Application.Command.Books.Commands.SaveBook;
using BooksLibrary.Application.Command.Mapping;

namespace BooksLibrary.WebApi.Model
{
    public class CreateBookDto : IMapWith<SaveBookCommand>
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Cover { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBookDto, SaveBookCommand>()
                  .ForMember(command => command.Id,
                              opt => opt.MapFrom(book => book.Id))
                  .ForMember(command => command.Title,
                              opt => opt.MapFrom(book => book.Title))
                  .ForMember(command => command.Genre,
                               opt => opt.MapFrom(book => book.Genre))
                  .ForMember(command => command.Content,
                              opt => opt.MapFrom(book => book.Content))
                  .ForMember(command => command.Author,
                               opt => opt.MapFrom(book => book.Author))
                  .ForMember(command => command.Cover,
                               opt => opt.MapFrom(book => book.Cover));
        }
    }
}
