using BooksLibrary.Application.Interfaces;
using BooksLibrary.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Command.Books.Commands.SaveReview
{
    public class SaveReviewCommandHandler : IRequestHandler<SaveReviewerCommand, int>
    {

        private readonly IBooksDbContext _booksDbContext;

        public SaveReviewCommandHandler(IBooksDbContext booksDbContext) =>
            _booksDbContext = booksDbContext;


        public async Task<int> Handle(SaveReviewerCommand request, CancellationToken cancellationToken)
        {

            var booksReview =  await _booksDbContext.Books.FirstOrDefaultAsync(book => book.Id == request.IdBook, cancellationToken);

            if (booksReview == null)
                throw new Exception($"Dont have book with Id  {request.IdBook} ");

            Review review = await Save(request, booksReview,  cancellationToken);

            return review.Id;

        }

        async Task<Review> Save(SaveReviewerCommand request, Book book, CancellationToken cancellationToken)
        {
            var Review = new Review
            {
                Book = book,
                BookId = book.Id,
                Message = request.Message,
                Reviewer = request.Reviewer
            };

            await _booksDbContext.Reviews.AddAsync(Review, cancellationToken);
            await _booksDbContext.SaveChangesAsync(cancellationToken);

            return Review;  
        }
    }
}
