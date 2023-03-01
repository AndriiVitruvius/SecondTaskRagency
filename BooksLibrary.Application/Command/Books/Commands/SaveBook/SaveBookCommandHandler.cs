using BooksLibrary.Application.Interfaces;
using BooksLibrary.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Command.Books.Commands.SaveBook
{

    /// <summary>
    /// Save Or update Book
    /// </summary>
    public class SaveBookCommandHandler : IRequestHandler<SaveBookCommand, uint>
    {

        private readonly IBooksDbContext _booksDbContext;

        public SaveBookCommandHandler(IBooksDbContext booksDbContext) =>
            _booksDbContext = booksDbContext;   

        async  Task<uint> IRequestHandler<SaveBookCommand, uint>.Handle(SaveBookCommand request, CancellationToken cancellationToken)
        {

            var entity = await _booksDbContext.Books.FirstOrDefaultAsync(book => book.Id == request.Id, cancellationToken);


            if (entity != null)
            {
                await Update(entity);
                return entity.Id;
            }


            Book Book = await Save(request, cancellationToken);
            return Book.Id;


            #region Function

            async Task Update(Book book)
            {
                book.Title = request.Title;
                book.Content = request.Content;
                book.Author = request.Author;
                book.Genre = request.Genre;
                book.Cover = request.Cover;

                await _booksDbContext.SaveChangesAsync(cancellationToken);

            }

            async Task<Book> Save(SaveBookCommand request, CancellationToken cancellationToken)
            {
                var Book = new Book
                {
                    Id = request.Id,
                    Title = request.Title,
                    Content = request.Content,
                    Author = request.Author,
                    Genre = request.Genre,
                    Cover = request.Cover,

                };

                await _booksDbContext.Books.AddAsync(Book, cancellationToken);
                await _booksDbContext.SaveChangesAsync(cancellationToken);
                return Book;
            } 
            #endregion
        }


    }
}
