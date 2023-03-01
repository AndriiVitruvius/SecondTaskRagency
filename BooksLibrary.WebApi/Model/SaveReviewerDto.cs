using AutoMapper;
using BooksLibrary.Application.Command.Books.Commands.SaveReview;
using BooksLibrary.Application.Command.Mapping;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BooksLibrary.WebApi.Model
{
    public class SaveReviewerDto : IMapWith<SaveReviewerCommand>
    {
        
        public string Message { get; set; }
        public string Reviewer { get; set; }
        public uint BookId { get; set; } 
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SaveReviewerDto, SaveReviewerCommand>()
                .ForMember(command => command.Message,
                             opt => opt.MapFrom(r => r.Message))
                .ForMember(command => command.Reviewer,
                             opt => opt.MapFrom(r => r.Reviewer))
                .ForMember(command => command.IdBook,
                             opt => opt.MapFrom(r => r.BookId));


        }
    }
}
