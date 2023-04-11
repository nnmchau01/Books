using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.ViewModels.Systems
{
    public class BookCreateRequestValidator : AbstractValidator<BookCreateRequest>
    {
        public BookCreateRequestValidator() 
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title value is required")
               .MaximumLength(255).WithMessage("Title cannot over limit 255 characters");
            RuleFor(x => x.AuthorId).NotEmpty()
                .WithMessage("AuthorId value is required");
        }
    }
}
