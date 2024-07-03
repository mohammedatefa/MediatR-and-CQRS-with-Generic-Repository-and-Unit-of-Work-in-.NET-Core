using CQRS_MediatR.Controllers.New.Request;
using FluentValidation;

namespace CQRS_MediatR.Utilities.Validators
{
    public class NewsInfoValidator:AbstractValidator<CreateOrUpdateNewRequest>
    {
        public NewsInfoValidator()
        {
            RuleFor(n=>n.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .MinimumLength(3).WithMessage("{PropertyName} Should Be More Than 3 Letters")
                .Must(IsLetter).WithMessage("{PropertyName} Should Be Letters ");

            RuleFor(n => n.Content)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .MinimumLength(3).WithMessage("{PropertyName} Should Be More Than 3 Letters")
                .MaximumLength(500).WithMessage("{PropertyName} Should Be More Than 500 Letters");

            RuleFor(n => n.Category)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .MinimumLength(3).WithMessage("{PropertyName} Should Be More Than 3 Letters")
                .Must(IsLetter).WithMessage("{PropertyName} Should Be Letters ");
        }
        private bool IsLetter(string value)
        {
            return value.All(char.IsLetter);
        }
    }
}
