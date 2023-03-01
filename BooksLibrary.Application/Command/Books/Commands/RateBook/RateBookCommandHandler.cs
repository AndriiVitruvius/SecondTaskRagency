using BooksLibrary.Application.Command.Books.Commands.SaveBook;
using BooksLibrary.Application.Command.Books.Commands.SaveReview;
using BooksLibrary.Application.Interfaces;
using BooksLibrary.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Command.Books.Commands.RateBook
{
    public class RateBookCommandHandler : IRequestHandler<RateBookCommand, uint>
    {

        private readonly IBooksDbContext _booksDbContext;

        public RateBookCommandHandler(IBooksDbContext booksDbContext) =>
            _booksDbContext = booksDbContext;


        public async Task<uint> Handle(RateBookCommand request, CancellationToken cancellationToken)
        {

            var booksReview = await _booksDbContext.Books.FirstOrDefaultAsync(book => book.Id == request.BookId, cancellationToken);

            if (booksReview == null)
                throw new Exception($"Dont have book with Id  {request.BookId} ");

            if(request.Score > 5  || request.Score < 1)
                throw new Exception($"The score must be from 1 to 5  {request.BookId} ");


            Rating review = await Save(request, booksReview, cancellationToken);

            return review.Id;

        }

        async Task<Rating> Save(RateBookCommand request, Book book, CancellationToken cancellationToken)
        {
            var Rating = new Rating
            {
                Book = book,
                BookId = book.Id,
                Score = request.Score,
            };

            await _booksDbContext.Ratings.AddAsync(Rating, cancellationToken);
            await _booksDbContext.SaveChangesAsync(cancellationToken);

            return Rating;
        }
    }
}
