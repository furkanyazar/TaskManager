using Business.Constants;
using Entities.Dtos;
using FluentValidation;
using System.Linq;

namespace Business.ValidationRules.FluentValidation
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(Messages.EmailNotEmpty);
            RuleFor(x => x.Email).EmailAddress().WithMessage(Messages.InvalidEmailAddress);
            RuleFor(x => x.Password).NotEmpty().WithMessage(Messages.PasswordNotEmpty);
            RuleFor(x => x.Password).MinimumLength(8).WithMessage(Messages.PasswordMinimumLength);
            RuleFor(x => x.Password).Must(ContainLetterAndNumber).WithMessage(Messages.PasswordMustContainLetterAndNumber);
        }

        private bool ContainLetterAndNumber(string arg)
        {
            return arg is not null && arg.Any(x => char.IsLetter(x)) && arg.Any(x => char.IsDigit(x));
        }
    }
}
