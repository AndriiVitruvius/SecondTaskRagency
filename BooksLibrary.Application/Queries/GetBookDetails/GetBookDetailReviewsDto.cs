using AutoMapper;
using BooksLibrary.Application.Command.Mapping;
using BooksLibrary.Application.Queries.GetAllBooks;
using BooksLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Queries.GetBookDetails
{
    public  class GetBookDetailReviewsDto 
    {

        public int Id { get; set; }
        public string Message { get; set; }
        public string Reviewer { get; set; }




    }
}
