using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<AllBooksVm>
    {
        public string Order { get; set; }
      

        
    }
}
