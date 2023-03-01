using BooksLibrary.Application.Queries.GetAllBooks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Queries.GetBookDetails
{
    public  class GetBookDetailsQuery : IRequest<GetBookDetailsQueryVm>
    {
        public uint BookId { get; set; }

    }
}
