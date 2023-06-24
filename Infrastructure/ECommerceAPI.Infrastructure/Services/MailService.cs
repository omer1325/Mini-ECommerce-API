using ECommerceAPI.Application.Abstractions.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace ECommerceAPI.Infrastructure.Services
{
    public class MailService : IMailService
    {
        readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMailAsync(new[] { to }, subject, body, isBodyHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
            foreach (var to in tos)
                mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new(_configuration["Mail:Username"], "E-Commerce", System.Text.Encoding.UTF8);

            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = _configuration["Mail:Host"];
            await smtp.SendMailAsync(mail);
        }

        public async Task SendPasswordResetMailAsync(string to, string userId, string resetToken)
        {
            StringBuilder mail = new();
            mail.AppendLine("Hello\r\nIf you have requested a new password, you can renew your password from the link below.<br><strong><a target=\"_blank\" href=\"");
            string str = _configuration["AngularClientUrl"] + "/update-password/" + userId + "/" + resetToken;
            mail.AppendLine(str);
            mail.AppendLine("\">Click for a new password request...\r\n...</a></strong><br><br><span style=\"font-size:12px;\">NOTE: If this request has not been fulfilled by you, please do not take this e-mail seriously.</span><br>Regards...<br><br><br> Mini | E-Ticaret");

            await SendMailAsync(to, "Şifre Yenileme Talebi", mail.ToString());
        }
    }
}
