using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserDetailDtoValidator : AbstractValidator<UserDetailDto>
    {
        public UserDetailDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
