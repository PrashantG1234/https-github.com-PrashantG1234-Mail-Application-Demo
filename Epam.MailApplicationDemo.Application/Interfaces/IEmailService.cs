namespace Epam.MailApplicationDemo.Application.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmailToAllAsync(string subject, string message);
    }
}
