using Microsoft.Extensions.Options;
using Epam.MailApplicationDemo.Domain.Repositories;
using MailKit.Net.Smtp;
using MimeKit;
using Epam.MailApplicationDemo.Infrastructure.Configurations;

namespace Epam.MailApplicationDemo.Infrastructure.Services
{
    public class EmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly EmailSettings _emailSettings;

        public EmailService(IEmailRepository emailRepository, IOptions<EmailSettings> emailSettings)
        {
            _emailRepository = emailRepository;
            _emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmailToAllAsync(string subject, string messageBody)
        {
            var emails = await _emailRepository.GetAllRegisteredEmailsAsync();

            if (emails.Count == 0)
                return false;

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("MailApplicationDemo", _emailSettings.SenderEmail));

            foreach (var email in emails)
            {
                emailMessage.To.Add(new MailboxAddress("", email.EmailAddress));
            }

            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = messageBody };

            using var client = new SmtpClient();
            await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, false);
            await client.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.SenderPassword);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);

            return true;
        }
    }
}
