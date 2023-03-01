using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Command.Books.Commands.RateBook
{
    public class RateBookCommand : IRequest<uint>
    {

        public uint BookId { get; set; }
        public int Score { get; set; }  
    }

}
