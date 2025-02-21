using Epam.MailApplicationDemo.Domain.Repositories;
using MailKit.Net.Smtp;
using MimeKit;

namespace Epam.MailApplicationDemo.Infrastructure.Services
{
    public class EmailService
    {
        private readonly IEmailRepository _emailRepository;

        public EmailService(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public async Task<bool> SendEmailToAllAsync(string subject, string messageBody)
        {
            var emails = await _emailRepository.GetAllRegisteredEmailsAsync();

            if (emails.Count == 0)
                return false;

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("MailApplicationDemo", "atulmanpur2003@gmail.com"));
            foreach (var email in emails)
            {
                emailMessage.To.Add(new MailboxAddress("", email.EmailAddress));
            }
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = messageBody };


            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, false);
            await client.AuthenticateAsync("atulmanpur2003@gmail.com", "gmgm rmqi kljs ugad");
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);

            return true;
        }
    }
}