using BusLiner.Domain.Entities;
using FluentValidation;

namespace BusLiner.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderQueryValidator : AbstractValidator<CreateOrderQuery>
    {
        public CreateOrderQueryValidator()
        {
            RuleFor(o => o.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(30).WithMessage("{PropertyName} should not exceed 30 characters.")
                .MinimumLength(3).WithMessage("{PropertyName} length should be greater or equals to 3.");

            RuleFor(o => o.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(30).WithMessage("{PropertyName} should not exceed 30 characters.")
                .MinimumLength(3).WithMessage("{PropertyName} length should be greater or equals to 3.");

            RuleFor(o => o.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .EmailAddress().WithMessage("{PropertyName} should be a valid email.")
                .MaximumLength(50).WithMessage("{PropertyName} should not exceed 50 characters.");

            RuleFor(o => o.Phone)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .Matches(@"^\d{10}$").WithMessage("{PropertyName} should be a valid phone number.");

            RuleFor(o => o.TicketsOrdered)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} should be greater or equals to 1.")
                .LessThanOrEqualTo(5).WithMessage("{PropertyName} should be less or equals to 5.");

            RuleFor(o => o.AdditionalBaggage)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(o => o)
                .Must(IsAdditionalBaggageNumberValid);
        }
        private bool IsAdditionalBaggageNumberValid(CreateOrderQuery order)
        {
            return !(order.TicketsOrdered * 2 >= order.AdditionalBaggage);
        }
    }
}
