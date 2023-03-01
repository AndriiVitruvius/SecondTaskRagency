using AutoMapper;
using BooksLibrary.Application.Command.Mapping;
using BooksLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Queries.GetAllBooks
{
    public class AllBooksVm 
    {
        public IList<GetAllBooksDto> AllBooksData { get; set; }
    }
}
