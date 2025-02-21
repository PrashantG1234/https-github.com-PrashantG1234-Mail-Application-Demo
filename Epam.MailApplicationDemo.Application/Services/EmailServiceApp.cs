using Epam.MailApplicationDemo.Application.Interfaces;
using Epam.MailApplicationDemo.Infrastructure.Services;

namespace Epam.MailApplicationDemo.Application.Services
{
    public class EmailServiceApp : IEmailService
    {
        private readonly EmailService _emailService;

        public EmailServiceApp(EmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task<bool> SendEmailToAllAsync(string subject, string message)
        {
            return await _emailService.SendEmailToAllAsync(subject, message);
        }
    }
}