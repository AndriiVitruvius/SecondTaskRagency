using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Command.Books.Commands.SaveBook
{
    public class SaveBookCommand : IRequest<uint>
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Cover { get; set; }

    }
}
