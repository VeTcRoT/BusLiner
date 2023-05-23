using FluentValidation;

namespace BusLiner.Application.Features.CustomTrips.Commands.UpdateCustomTrip
{
    public class UpdateCustomTripCommandValidator : AbstractValidator<UpdateCustomTripCommand>
    {
        public UpdateCustomTripCommandValidator()
        {
            RuleFor(c => c.From)
                .NotEmpty().WithMessage("Звідки є необхідним.")
                .NotNull()
                .MaximumLength(30).WithMessage("Довжина звідки має бути не більшою 30 символів.")
                .MinimumLength(4).WithMessage("Довжина звідки має бути не меншою 4 символів.");

            RuleFor(c => c.To)
                .NotEmpty().WithMessage("Куди є необхідним.")
                .NotNull()
                .MaximumLength(30).WithMessage("Довжина куди має бути не більшою 30 символів.")
                .MinimumLength(4).WithMessage("Довжина куди має бути не меншою 4 символів.");

            RuleFor(c => c.DepartureTime)
                .NotEmpty().WithMessage("Дата відправлення є необхідною.")
                .NotNull();

            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("Ім'я є необхідним.")
                .NotNull()
                .MaximumLength(30).WithMessage("Довжина ім'я має бути не більшою 30 символів.")
                .MinimumLength(3).WithMessage("Довжина ім'я має бути не меншою 3 символів.");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Прізвище є необхідним.")
                .NotNull()
                .MaximumLength(30).WithMessage("Довжина прізвища має бути не більшою 30 символів.")
                .MinimumLength(3).WithMessage("Довжина прізвища має бути не меншою 3 символів.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email є необхідним.")
                .NotNull()
                .EmailAddress().WithMessage("Email введено в неправильному форматі.")
                .MaximumLength(50).WithMessage("Довжина email має бути не більшою 50 символів.");

            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("Телефон є необхідним.")
                .NotNull()
                .Matches(@"^\d{10}$").WithMessage("Телефон введено в неправильному форматі.");

            RuleFor(c => c.AmountOfPassengers)
                .NotEmpty().WithMessage("К-сть пасажирів є необхідною.")
                .GreaterThanOrEqualTo(1).WithMessage("К-сть пасажирів має бути більше 1.")
                .LessThanOrEqualTo(200).WithMessage("К-сть пасажирів немає перевищувати 200.");
        }
    }
}
