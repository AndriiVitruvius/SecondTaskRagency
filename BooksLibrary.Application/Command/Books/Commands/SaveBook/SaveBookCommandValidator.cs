using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Command.Books.Commands.SaveBook
{
    public class SaveBookCommandValidator : AbstractValidator<SaveBookCommand>
    {
        public SaveBookCommandValidator()
        {
            RuleFor(saveBookCommand => saveBookCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(saveBookCommand => saveBookCommand.Author).NotEmpty().MaximumLength(250).MinimumLength(3);
            RuleFor(saveBookCommand => saveBookCommand.Genre).NotEmpty().MaximumLength(512);
            RuleFor(saveBookCommand => saveBookCommand.Cover).NotEmpty();
        }
    }
}
