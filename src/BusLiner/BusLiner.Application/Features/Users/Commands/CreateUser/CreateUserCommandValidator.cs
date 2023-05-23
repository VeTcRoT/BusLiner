using FluentValidation;

namespace BusLiner.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress().WithMessage("Email введений в неправильному форматі.");

            RuleFor(u => u.Password)
                .MinimumLength(6).WithMessage("Довжина паролю не може бути меншою за 6.")
                .Matches(@"^(?=.*[A-Z])(?=.*\w).*$").WithMessage("Пароль має містити принаймі одну цифру та одну велику букву.");

            RuleFor(u => u.Role)
                .Must(IsRightRole).WithMessage("Роль невірна.");

            RuleFor(u => u.EmailConfirmed)
                .Must(EmailConfirmedRightValue).WithMessage("Невірне значення для EmailConfirmed.");
        }
        private bool IsRightRole(string role)
        {
            return role == "Admin" || role == "Manager" || role == "User";
        }
        private bool EmailConfirmedRightValue(int emailConfirmed)
        {
            return emailConfirmed == 0 || emailConfirmed == 1;
        }
    }
}
