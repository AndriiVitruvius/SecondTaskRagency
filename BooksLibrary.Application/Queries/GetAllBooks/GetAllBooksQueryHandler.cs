using AutoMapper;
using AutoMapper.QueryableExtensions;
using BooksLibrary.Application.Interfaces;
using BooksLibrary.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, AllBooksVm>
    {
        private readonly IBooksDbContext _booksDbContext;
        private readonly IMapper _mapper;

        public GetAllBooksQueryHandler(IBooksDbContext booksDbContext , IMapper mapper) =>
                       (_booksDbContext, _mapper) = ( booksDbContext, mapper ) ;


        public async Task<AllBooksVm> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            string requestString = request.Order;

            var books = await _booksDbContext.Books.ProjectTo<GetAllBooksDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            if (books == null || books.Count == 0)
                throw new  Exception( $"Don't have  books {requestString} ");

            if (requestString == "author")
                books.OrderBy(b => b.Author);
            else if(requestString == "title")
                books.OrderBy(b => b.Title);


            return new AllBooksVm { AllBooksData = books };

        }
    }
}
