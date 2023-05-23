using BusLiner.Application.Features.Orders.Commands.CreateOrder;
using FluentValidation;

namespace BusLiner.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(o => o.FirstName)
                .NotEmpty().WithMessage("Ім'я є необхідним.")
                .NotNull()
                .MaximumLength(30).WithMessage("Довжина ім'я має бути не більшою 30 символів.")
                .MinimumLength(3).WithMessage("Довжина ім'я має бути не меншою 3 символів.");

            RuleFor(o => o.LastName)
                .NotEmpty().WithMessage("Прізвище є необхідним.")
                .NotNull()
                .MaximumLength(30).WithMessage("Довжина прізвища має бути не більшою 30 символів.")
                .MinimumLength(3).WithMessage("Довжина прізвища має бути не меншою 3 символів.");

            RuleFor(o => o.Email)
                .NotEmpty().WithMessage("Email є необхідним.")
                .NotNull()
                .EmailAddress().WithMessage("Email введено в неправильному форматі.")
                .MaximumLength(50).WithMessage("Довжина email має бути не більшою 50 символів.");

            RuleFor(o => o.Phone)
                .NotEmpty().WithMessage("Телефон є необхідним.")
                .NotNull()
                .Matches(@"^\d{10}$").WithMessage("Телефон введено в неправильному форматі.");

            RuleFor(o => o.TicketsOrdered)
                .NotEmpty().WithMessage("К-сть замовлених квитків є необхідним.")
                .GreaterThanOrEqualTo(1).WithMessage("Мінімальне значення к-сті замовлених квитків є 1.")
                .LessThanOrEqualTo(5).WithMessage("Не можна замовити більше 5 квитків.");

            RuleFor(o => o)
                .Must(IsAdditionalBaggageNumberValid).WithMessage("К-сть додаткового багажу немає перевищувати к-сть білетів помножену на 2.");
        }
        private bool IsAdditionalBaggageNumberValid(UpdateOrderCommand order)
        {
            return order.AdditionalBaggage >= 0 && order.TicketsOrdered * 2 >= order.AdditionalBaggage;
        }
    }
}
