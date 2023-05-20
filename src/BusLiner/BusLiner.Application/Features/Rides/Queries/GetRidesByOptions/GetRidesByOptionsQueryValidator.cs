using FluentValidation;

namespace BusLiner.Application.Features.Rides.Queries.GetRidesByOptions
{
    public class GetRidesByOptionsQueryValidator : AbstractValidator<GetRidesByOptionsQuery>
    {
        public GetRidesByOptionsQueryValidator()
        {
            RuleFor(o => o.From)
                .NotEmpty().WithMessage("Звідки є необхідним.")
                .NotNull()
                .MaximumLength(30).WithMessage("Довжина звідки має бути не більшою 30 символів.")
                .MinimumLength(4).WithMessage("Довжина звідки має бути не більшою 4 символів.");

            RuleFor(o => o.To)
                .NotEmpty().WithMessage("Куди є необхідним.")
                .NotNull()
                .MaximumLength(30).WithMessage("Довжина куди має бути не більшою 30 символів.")
                .MinimumLength(4).WithMessage("Довжина куди має бути не більшою 4 символів.");

            RuleFor(u => u.DepartureDate)
                .NotEmpty().WithMessage("Дата відправлення є необхідною.")
                .NotNull()
                .Must(BeAValidDate).WithMessage("Дата відправлення введена в неправильному форматі.");
        }
        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
