using Epam.MailApplicationDemo.Domain.Entities;
using Epam.MailApplicationDemo.Domain.Repositories;
using Epam.MailApplicationDemo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Epam.MailApplicationDemo.Infrastructure.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly AppDbContext _context;

        public EmailRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Email>> GetAllRegisteredEmailsAsync()
        {
            return await _context.Emails.ToListAsync();
        }
    }
}
