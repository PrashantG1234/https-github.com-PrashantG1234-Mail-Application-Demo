using Epam.MailApplicationDemo.Application.Interfaces;
using Epam.MailApplicationDemo.Application.Services;
using Epam.MailApplicationDemo.Domain.Repositories;
using Epam.MailApplicationDemo.Infrastructure.Data;
using Epam.MailApplicationDemo.Infrastructure.Repositories;
using Epam.MailApplicationDemo.Infrastructure.Services;
using Epam.MailApplicationDemo.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Load connection string from environment variables
var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Database connection string is missing. Ensure 'DefaultConnection' is set in environment variables.");
}

// Configure EmailSettings using environment variables
var emailSettings = new EmailSettings
{
    SmtpServer = Environment.GetEnvironmentVariable("SmtpServer"),
    SmtpPort = int.Parse(Environment.GetEnvironmentVariable("SmtpPort") ?? "587"),
    SenderEmail = Environment.GetEnvironmentVariable("SenderEmail"),
    SenderPassword = Environment.GetEnvironmentVariable("SenderPassword")
};

builder.Services.AddSingleton(emailSettings);


// Configure DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IEmailRepository, EmailRepository>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<IEmailService, EmailServiceApp>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "Home", action = "Index" }
);

app.Run();
