using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Application.Activities.CreateActivity
{
    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Venue).NotEmpty();
            RuleFor(x => x.Category).NotEmpty();
        }
    }
}
