using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Command.Books.Commands.Delete
{
    public class DeleteBookCommand : IRequest
    {
        public  uint Id { get; set; }   

        public string Key { get; set; }
    }
}
