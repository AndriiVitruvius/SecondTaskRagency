using AutoMapper;
using BooksLibrary.Application.Command.Mapping;
using BooksLibrary.Application.Queries.GetAllBooks;
using BooksLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Queries.GetTop10
{
    public class GetTop10Dto : IMapWith<Book>
    {
        public uint Id { get; set; }    
        public string Title { get; set; }
        public string Author { get; set; }
        public int ReviewsNumber { get; set; }
        public double Ratings { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, GetTop10Dto>()
               .ForMember(BookDto => BookDto.Id,
                   opt => opt.MapFrom(book => book.Id))
                .ForMember(BookDto => BookDto.Title,
                   opt => opt.MapFrom(book => book.Title))
               .ForMember(BookDto => BookDto.Author,
                   opt => opt.MapFrom(book => book.Author))
               .ForMember(BookDto => BookDto.ReviewsNumber,
                   opt => opt.MapFrom(book => book.Reviews != null ? book.Reviews.Count : 0))
               .ForMember(dest => dest.Ratings, opt => opt.MapFrom(src =>
                src.Ratings != null && src.Ratings.Any() ? src.Ratings.Average(r => r.Score) : 0.00));

        }
    }
}
