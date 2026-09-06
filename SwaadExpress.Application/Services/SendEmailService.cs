using Microsoft.Extensions.Options;
using Resend;
using SwaadExpress.Application.Contracts.Service;
using SwaadExpress.Domain.Modal.Entity;

namespace KaryaSync.ThirdPartyIntegrations.Services
{
    public class SendEmailService : ISendEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly IResend _resend;

        public SendEmailService(IOptions<EmailSettings> emailSettings, IResend resend)
        {
            _emailSettings = emailSettings.Value;
            _resend = resend;
        }

        public async Task SendOtp(string emailAddress, string otp)
        {
            var body = string.Format(
                _emailSettings.OtpEmailBodyTemplate,
                otp,
                _emailSettings.OtpExpiryTime);

            var message = new EmailMessage
            {
                From = _emailSettings.SenderEmail,
                Subject = _emailSettings.OtpEmailSubject,
                TextBody = body
            };
            message.To.Add(emailAddress);

            await _resend.EmailSendAsync(message);
        }
    }
}