using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CQRS_MediatR.Application.Members.Commands.Validations
{
    public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
    {
        public CreateMemberCommandValidator() 
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("Please ensure you have entered the FirstName.")
                .Length(4, 100).WithMessage("The FirstName must have betweeen 4 and 100 characters");

            RuleFor(c => c.LastName).NotEmpty().WithMessage("Please ensure you have entered the LastName.")
                .Length(4, 100).WithMessage("The LastName must have betweeen 4 and 100 characters");

            RuleFor(c => c.Gender).NotEmpty().MinimumLength(4).WithMessage("The gender must be a valid information.");

            RuleFor(c => c.Email).NotEmpty().EmailAddress();

            RuleFor(c => c.IsActive).NotNull();

        }
    }
}
