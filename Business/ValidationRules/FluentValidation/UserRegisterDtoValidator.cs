using Business.Constants;
using Entities.Dtos;
using FluentValidation;
using System.Linq;

namespace Business.ValidationRules.FluentValidation
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(Messages.EmailNotEmpty);
            RuleFor(x => x.Email).EmailAddress().WithMessage(Messages.InvalidEmailAddress);
            RuleFor(x => x.Password).NotEmpty().WithMessage(Messages.PasswordNotEmpty);
            RuleFor(x => x.Password).MinimumLength(6).WithMessage(Messages.PasswordMinimumLength);
            RuleFor(x => x.Password).Must(ContainLetterAndNumber).WithMessage(Messages.PasswordMustContainLetterAndNumber);
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(Messages.FirstNameNotEmpty);
            RuleFor(x => x.FirstName).MinimumLength(2).WithMessage(Messages.FirstNameMinimumLength);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(Messages.LastNameNotEmpty);
            RuleFor(x => x.LastName).MinimumLength(2).WithMessage(Messages.LastNameMinimumLength);
        }

        private bool ContainLetterAndNumber(string arg)
        {
            return arg.Any(x => char.IsLetter(x)) && arg.Any(x => char.IsDigit(x));
        }
    }
}
