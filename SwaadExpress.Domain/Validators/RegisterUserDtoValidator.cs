using FluentValidation;
using SwaadExpress.Domain.Modal.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.Domain.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {

        public RegisterUserDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email address");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Username is required.")
                .MinimumLength(3)
                .WithMessage("Username must be at least 3 characters.")
                .MaximumLength(50)
                .WithMessage("Username must not exceed 50 characters.")
                .Matches("^[a-zA-Z0-9_]+$")
                .WithMessage("Username can contain only letters, numbers, and underscore.");

        }
    }
}
