using Cats.Logic.Validators.Interfaces;
using FluentValidation;

namespace Cats.Logic.Validators
{
    public class GetBreedsValidator : AbstractValidator<string>, IGetBreedsValidator
    {
        public GetBreedsValidator()
        {
            RuleFor(term => term)
                .NotEmpty()
                .WithMessage("Search term should not be empty")
                .MaximumLength(50)
                .WithMessage("Search term should not exceed 50 characters");
        }
    }
}
