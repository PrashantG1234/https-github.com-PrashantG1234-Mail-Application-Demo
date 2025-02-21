using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MailApplicationDemo.Application.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmailToAllAsync(string subject, string message);
    }
}
