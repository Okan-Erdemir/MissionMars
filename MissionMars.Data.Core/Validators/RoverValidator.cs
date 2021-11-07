using FluentValidation;
using MissionMars.Data.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissionMars.Data.Core.Validators
{
    public class RoverValidator : AbstractValidator<Rover>
    {
        public RoverValidator()
        {
            RuleFor(rover => rover.DirectionType).NotNull().IsInEnum().WithMessage(rover =>
            $"{rover.DirectionType} is wrong direction value.");

            RuleFor(rover => rover.MarsSurface.EdgeX).GreaterThanOrEqualTo(0).WithMessage("can be not null");
            RuleFor(rover => rover.MarsSurface.EdgeY).GreaterThanOrEqualTo(0).WithMessage("can be not null");

            RuleFor(rover => rover.Coordinates.X).GreaterThanOrEqualTo(0)
             .LessThanOrEqualTo(rover => rover.MarsSurface.EdgeX)
             .WithMessage("Rover must be inside the plateau");

            RuleFor(rover => rover.Coordinates.Y).GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(rover => rover.MarsSurface.EdgeY)
                .WithMessage("Rover must be inside the plateau");
        }

    }
}
