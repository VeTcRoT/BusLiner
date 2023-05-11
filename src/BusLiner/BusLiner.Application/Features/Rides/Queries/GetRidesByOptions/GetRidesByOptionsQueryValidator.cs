using FluentValidation;

namespace BusLiner.Application.Features.Rides.Queries.GetRidesByOptions
{
    public class GetRidesByOptionsQueryValidator : AbstractValidator<GetRidesByOptionsQuery>
    {
        public GetRidesByOptionsQueryValidator()
        {
            RuleFor(o => o.From)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(30).WithMessage("{PropertyName} should not exceed 30 characters.")
                .MinimumLength(5).WithMessage("{PropertyName} length should be greater or equals to 5 characters.");

            RuleFor(o => o.To)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(30).WithMessage("{PropertyName} should not exceed 30 characters.")
                .MinimumLength(5).WithMessage("{PropertyName} length should be greater or equals to 5 characters.");

            RuleFor(u => u.DepartureDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .Must(BeAValidDate).WithMessage("{PropertyName} enetered in wrong format.");
        }
        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
