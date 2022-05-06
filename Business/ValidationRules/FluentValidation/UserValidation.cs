using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
        }
    }
}
