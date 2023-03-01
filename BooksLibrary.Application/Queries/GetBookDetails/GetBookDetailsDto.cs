using AutoMapper;
using BooksLibrary.Application.Command.Mapping;
using BooksLibrary.Application.Queries.GetAllBooks;
using BooksLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Queries.GetBookDetails
{
    public  class GetBookDetailsDto : IMapWith<Book>
    {
        public uint Id { get; set; }    
        public string Title { get; set; }
        public string Author { get; set; }

        public string Cover { get; set; }   
        public List<GetBookDetailReviewsDto> Reviews { get; set; }
        public double Ratings { get; set; }
        public string Genre { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, GetBookDetailsDto>()
                .ForMember(BookDto => BookDto.Title,
                   opt => opt.MapFrom(book => book.Title))
               .ForMember(BookDto => BookDto.Author,
                   opt => opt.MapFrom(book => book.Author))
               .ForMember(BookDto => BookDto.Cover,
                   opt => opt.MapFrom(book => book.Cover))
               .ForMember(BookDto => BookDto.Genre,
                   opt => opt.MapFrom(book => book.Genre))
               .ForMember(BookDto => BookDto.Reviews,
                   opt => opt.MapFrom(book => book.Reviews != null ? book.Reviews.Select(r => new GetBookDetailReviewsDto
                   {
                       Id = r.Id,
                       Message = r.Message,
                       Reviewer = r.Reviewer
                   }).ToList() : new List<GetBookDetailReviewsDto>()))



               .ForMember(dest => dest.Ratings, opt => opt.MapFrom(src =>
                   src.Ratings != null && src.Ratings.Any() ? src.Ratings.Average(r => r.Score) : 0.00));

        }
    }
}
