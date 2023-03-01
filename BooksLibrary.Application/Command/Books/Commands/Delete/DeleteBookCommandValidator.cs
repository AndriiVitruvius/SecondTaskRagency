using FluentValidation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Command.Books.Commands.Delete
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(x => x.Key).Equal(ConfigurationManager.AppSettings["SecretKey"]).WithMessage("Wrong key").WithErrorCode("401");
        }
    
    }
}
