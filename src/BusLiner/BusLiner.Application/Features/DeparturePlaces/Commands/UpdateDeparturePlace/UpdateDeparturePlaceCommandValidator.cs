﻿using FluentValidation;

namespace BusLiner.Application.Features.DeparturePlaces.Commands.UpdateDeparturePlace
{
    public class UpdateDeparturePlaceCommandValidator : AbstractValidator<UpdateDeparturePlaceCommand>
    {
        public UpdateDeparturePlaceCommandValidator()
        {
            RuleFor(p => p.City)
                .MinimumLength(4).WithMessage("Довжина міста не може бути меншою за 4 символа.")
                .MaximumLength(40).WithMessage("Довжина міста не може бути більшою за 40 символів.");

            RuleFor(p => p.Station)
                .MinimumLength(4).WithMessage("Довжина станції не може бути меншою за 4 символа.")
                .MaximumLength(40).WithMessage("Довжина станції не може бути більшою за 40 символів.");

            RuleFor(p => p.Street)
                .MinimumLength(4).WithMessage("Довжина вулиці не може бути меншою за 4 символа.")
                .MaximumLength(40).WithMessage("Довжина вулиці не може бути більшою за 40 символів.");
        }
    }
}