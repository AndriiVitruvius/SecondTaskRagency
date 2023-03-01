using AutoMapper;
using BooksLibrary.Application.Command.Books.Commands.RateBook;
using BooksLibrary.Application.Command.Books.Commands.SaveReview;
using BooksLibrary.Application.Command.Mapping;

namespace BooksLibrary.WebApi.Model
{
    public class RateBookDto : IMapWith<RateBookCommand>
    {

        public uint BookId { get; set; }
        public int Score { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<RateBookDto, RateBookCommand>()
                .ForMember(command => command.BookId,
                             opt => opt.MapFrom(r => r.BookId))
                .ForMember(command => command.Score,
                             opt => opt.MapFrom(r => r.Score));
        }


    }
}
