using BusLiner.Application.Features.Users.Commands.CreateUser;
using FluentValidation;

namespace BusLiner.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress().WithMessage("Email введений в неправильному форматі.");

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
