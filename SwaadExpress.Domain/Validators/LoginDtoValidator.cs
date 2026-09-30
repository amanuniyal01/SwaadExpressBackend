using FluentValidation;
using SwaadExpress.Domain.Modal.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.Domain.Validators
{
    public class LoginDtoValidator:AbstractValidator<LoginDto>
    {

        public LoginDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email address");

            RuleFor(x=>x.Otp)
                .Length(4).WithMessage("OTP must be exactly 4 digits")
                .Matches(@"^\d{4}$").WithMessage("OTP can only contain numbers");
        }
    }
}
