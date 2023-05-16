using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;

namespace BusLiner.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("busliner@outlook.com", "Test12345678!")
            };

            var mail = new MailMessage(from: "busliner@outlook.com", to: email, subject, htmlMessage);
            mail.IsBodyHtml = true;

            return client.SendMailAsync(mail);
        }
    }
}
