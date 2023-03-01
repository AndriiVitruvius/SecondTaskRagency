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

namespace BooksLibrary.Application.Queries.GetTop10
{
    internal class GetTop10QueryHandler : IRequestHandler<GetTop10Query, GetTop10Vm>
    {
        private readonly IBooksDbContext _booksDbContext;
        private readonly IMapper _mapper;

        public GetTop10QueryHandler(IBooksDbContext booksDbContext, IMapper mapper) =>
                       (_booksDbContext, _mapper) = (booksDbContext, mapper);


        public async Task<GetTop10Vm> Handle(GetTop10Query request, CancellationToken cancellationToken)
        {
            string requestString = request.Order;

            var books = await _booksDbContext.Books.Where(b => b.Genre == requestString)
                                                   .ProjectTo<GetTop10Dto>(_mapper.ConfigurationProvider)
                                                   .OrderBy(b => b.Ratings).ToListAsync(cancellationToken);

            if (books == null || books.Count == 0)
                throw new Exception($"Don't have  books {requestString} ");

            IEnumerable<GetTop10Dto> enumerable = books.Take(10);


            return new GetTop10Vm { Top10Books = enumerable.ToList() };

        }

    }
}
