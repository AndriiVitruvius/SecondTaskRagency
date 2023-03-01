using BooksLibrary.Application.Queries.GetAllBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Queries.GetTop10
{
    public class GetTop10Vm
    {
        public IList<GetTop10Dto> Top10Books { get; set; }

    }
}
