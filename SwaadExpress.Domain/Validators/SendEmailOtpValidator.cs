using FluentValidation;
using SwaadExpress.Domain.Modal.Dto;

namespace SwaadExpress.Domain.Validators
{
    public class SendEmailOtpValidator : AbstractValidator<SendEmailOtpDto>
    {
        public SendEmailOtpValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email address");
        }
    }
}