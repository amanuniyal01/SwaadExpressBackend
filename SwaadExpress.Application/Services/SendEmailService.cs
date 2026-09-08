using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SwaadExpress.Application.Contracts.Service;
using SwaadExpress.Domain.Modal.Entity;

namespace KaryaSync.ThirdPartyIntegrations.Services
{
    public class SendEmailService : ISendEmailService
    {
        private readonly EmailSettings _emailSettings;

        public SendEmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendOtp(string emailAddress, string otp)
        {
            var email = new MimeMessage();

           
            email.From.Add(
                new MailboxAddress(
                    _emailSettings.SenderName,
                    _emailSettings.SenderEmail
                )
            );

            email.To.Add(MailboxAddress.Parse(emailAddress));

            email.Subject = _emailSettings.OtpEmailSubject;

            var body = $"""
             <html>
             <body>
        <div style="
            max-width: 500px;
            margin: auto;
            padding: 30px;
            font-family: Arial, sans-serif;
            text-align: center;
            border: 1px solid #ddd;
            border-radius: 10px;">

            <h1>SwaadExpress</h1>

            <h2>Your OTP</h2>

            <p>
                Use the following OTP to continue:
            </p>

            <div style="
                font-size: 32px;
                font-weight: bold;
                letter-spacing: 8px;
                margin: 25px 0;">
                {otp}
            </div>

            <p>
                This OTP will expire in
                <strong>{_emailSettings.OtpExpiryTime} minutes</strong>.
            </p>

            <p style="color: #777; font-size: 13px;">
                If you didn't request this OTP,
                you can safely ignore this email.
            </p>

        </div>
    </body>
    </html>
    """;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = body
            };

            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();

            await smtp.ConnectAsync(
                "smtp.gmail.com",
                587,
                SecureSocketOptions.StartTls
            );
          
            await smtp.AuthenticateAsync(
                _emailSettings.SenderEmail,
                _emailSettings.AppPassword
            );

            await smtp.SendAsync(email);

            await smtp.DisconnectAsync(true);
        }
    }
}