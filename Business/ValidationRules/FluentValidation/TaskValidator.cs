using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TaskValidator : AbstractValidator<Task>
    {
        public TaskValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage(Messages.DescriptionNotEmpty);
            RuleFor(x => x.Description).MinimumLength(3).WithMessage(Messages.DescriptionMinimumLength);
        }
    }
}
