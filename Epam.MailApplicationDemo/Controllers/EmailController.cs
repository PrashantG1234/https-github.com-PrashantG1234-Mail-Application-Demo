using Epam.MailApplicationDemo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Epam.MailApplicationDemo.Presentation.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult Compose() => View();

        [HttpPost]
        public async Task<IActionResult> SendEmail(string subject, string message)
        {
            bool isSent = await _emailService.SendEmailToAllAsync(subject, message);
            ViewBag.Message = isSent ? "Email sent successfully!" : "No registered emails.";
            return View("Compose");
        }
    }
}
