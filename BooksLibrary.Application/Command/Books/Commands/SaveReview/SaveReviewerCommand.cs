using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Command.Books.Commands.SaveReview
{
    public class SaveReviewerCommand : IRequest<int>
    {
        public uint IdBook { get; set; }
        public string Message { get; set; }
        public string Reviewer { get; set; }


    }
}
