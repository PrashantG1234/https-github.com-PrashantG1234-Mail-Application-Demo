using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.MailApplicationDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Epam.MailApplicationDemo.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Email> Emails { get; set; }
    }
}
