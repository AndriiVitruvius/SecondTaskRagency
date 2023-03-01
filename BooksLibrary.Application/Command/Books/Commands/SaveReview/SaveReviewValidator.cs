using BooksLibrary.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Command.Books.Commands.SaveReview
{
    internal class SaveReviewValidator : AbstractValidator<SaveReviewerCommand>
    {
        public SaveReviewValidator() 
        {
            RuleFor(reviewCommnd => reviewCommnd.Message).NotEmpty().MaximumLength(512);
            RuleFor(reviewCommnd => reviewCommnd.Reviewer).NotEmpty().MaximumLength(250);
        }
    }
}
