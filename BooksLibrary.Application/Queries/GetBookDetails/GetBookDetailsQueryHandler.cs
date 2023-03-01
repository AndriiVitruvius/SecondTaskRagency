using AutoMapper;
using AutoMapper.QueryableExtensions;
using BooksLibrary.Application.Interfaces;
using BooksLibrary.Application.Queries.GetAllBooks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Queries.GetBookDetails
{
    public class GetBookDetailsQueryHandler : IRequestHandler<GetBookDetailsQuery, GetBookDetailsQueryVm>
    {

        private readonly IBooksDbContext _booksDbContext;
        private readonly IMapper _mapper;

        public GetBookDetailsQueryHandler(IBooksDbContext booksDbContext, IMapper mapper) =>
                       (_booksDbContext, _mapper) = (booksDbContext, mapper);



        public async Task<GetBookDetailsQueryVm> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
        {
            var books = await _booksDbContext.Books.ProjectTo<GetBookDetailsDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(book => book.Id == request.BookId, cancellationToken);


            if (books == null)
                throw new Exception($"Don't have  books {request.BookId} ");


            return new GetBookDetailsQueryVm {BookDetails = books} ;



        }
    }
}
