using Epam.MailApplicationDemo.Domain.Entities;

namespace Epam.MailApplicationDemo.Domain.Repositories
{
    public interface IEmailRepository
    {
        Task<List<Email>> GetAllRegisteredEmailsAsync();
    }
}
