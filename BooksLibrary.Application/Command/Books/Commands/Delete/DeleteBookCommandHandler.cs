using BooksLibrary.Application.Interfaces;
using BooksLibrary.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Command.Books.Commands.Delete
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBooksDbContext _booksDbContext;
        public DeleteBookCommandHandler(IBooksDbContext booksDbContext) =>
            _booksDbContext = booksDbContext;

        public  async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var entity = await _booksDbContext.Books.FindAsync (new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFiniteNumberException(nameof(Book), request.Id);

            _booksDbContext.Books.Remove(entity);
            await _booksDbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
