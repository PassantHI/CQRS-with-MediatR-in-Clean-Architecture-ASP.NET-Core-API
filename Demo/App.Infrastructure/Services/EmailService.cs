using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Services
{
    public class EmailService:IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string email, string subject, string body)
        {

            var smtpclient = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("*********EMAIL", "*******password"),
                EnableSsl = true
            };


            var mailmassege = new MailMessage
            {
                From = new MailAddress("*********EMAIL"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };


            mailmassege.To.Add(email);

            await smtpclient.SendMailAsync(mailmassege);
        }

    }
}
