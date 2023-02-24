using FluentValidation;
using UsersAPI.Contracts.Data.InputModels;

namespace UsersAPI.Database.Validators
{
    public class UserInputValidator : AbstractValidator<UserInput>
    {
        public UserInputValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(20);

            RuleFor(x => x.Age)
                .NotNull()
                .GreaterThanOrEqualTo(14);


        }
    }
}
