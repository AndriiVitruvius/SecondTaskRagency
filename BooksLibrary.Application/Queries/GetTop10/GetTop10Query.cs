using BooksLibrary.Application.Queries.GetAllBooks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Queries.GetTop10
{
    public class GetTop10Query : IRequest<GetTop10Vm>
    {
        public string Order { get; set; }


    }
}
