using Epam.MailApplicationDemo.Application.Interfaces;
using Epam.MailApplicationDemo.Application.Services;
using Epam.MailApplicationDemo.Domain.Repositories;
using Epam.MailApplicationDemo.Infrastructure.Data;
using Epam.MailApplicationDemo.Infrastructure.Repositories;
using Epam.MailApplicationDemo.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Load connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IEmailRepository, EmailRepository>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<IEmailService, EmailServiceApp>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Email}/{action=Compose}/{id?}"));

app.Run();
