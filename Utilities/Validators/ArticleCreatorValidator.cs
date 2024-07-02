using CQRS_MediatR.Controllers.ArticleCreator.Request;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CQRS_MediatR.Utilities.Validators
{
    public class ArticleCreatorValidator:AbstractValidator<CreateOrUpdateCreatorRequest>
    {
        public ArticleCreatorValidator()
        {

            #region Name Validation
            RuleFor(ac => ac.Name)
                 .NotEmpty().WithMessage("Name Can Not Be Empty !!")
                 .NotNull().WithMessage("Name Can Not Be Null !!")
                 .Must(ac => CreatorNameValidator().IsMatch(ac)).WithMessage("Must be between 3 and 50 characters long.\r\nCan only contain letters, spaces, hyphens, and apostrophes.\r\nNo leading or trailing spaces")
                 .WithName("Article Creator Name");
            #endregion

            #region Email Validation
            RuleFor(ac => ac.Email)
                  .NotEmpty().WithMessage("Email Can Not Be Empty !!")
                  .NotNull().WithMessage("Email Can Not Be Null !!")
                  .Must(email => CreatorEmailValidator().IsMatch(email)).WithMessage("In valid Email \r\nMust start with one or more alphanumeric characters or specific special characters \r\n must Contaion @ \r\n end with domain name ").WithName("Article Creator Email");

            #endregion

            #region Password Validation
            RuleFor(ac => ac.Password)
               .NotEmpty().WithMessage("Password Can Not Be Empty !!")
               .NotNull().WithMessage("Password Can Not Be Null !!")
               .Must(password => CreatorPasswordValidator().IsMatch(password)).WithMessage("invalid Password \r\nMust start with a capital letter.\r\nMust contain both letters and numbers.\r\nMust contain exactly one special character.\r\nMust not contain spaces.\r\nMinimum length of 8 characters. ").WithName("Article Creator Password"); 
            #endregion
             
        }
        private static Regex CreatorNameValidator() => new Regex(@"^(?! )[A-Za-z' -]{3,50}(?<! )$");
        private static Regex CreatorEmailValidator() => new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        private static Regex CreatorPasswordValidator() => new Regex(@"^(?=.*[A-Z])(?=.*[a-zA-Z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}:;<>,.?/~`-])[A-Za-z\\d!@#$%^&*()_+{}:;<>,.?/~`-]{8,}$\r\n");
    }
}
