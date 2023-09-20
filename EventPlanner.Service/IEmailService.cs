using EventPlanner.Data.Configuration;
using EventPlanner.Domain.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Service
{
    public interface IEmailService
    {
        bool SendEmail(EmailData emailData);
    }

    public class EmailService : IEmailService
    {
        EmailSettings _emailSettings = null;
        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public bool SendEmail(EmailData emailData)
        {
            try
            {
                emailData.EmailBody = "<html><body>Hello,<p>" + emailData.EmailBody + "</p><p>Best regards,<br> <img src='https://i0.wp.com/www.recruter.tn/wp-content/uploads/2018/03/logo-FinlogiK-b.gif?fit=300%2C79&ssl=1'></p></body></html>";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(_emailSettings.EmailId);
                mail.To.Add(new MailAddress(emailData.EmailToId));
                mail.Subject = emailData.EmailSubject;
                mail.IsBodyHtml = true; // Set this property to true to send an HTML email
                mail.Body = emailData.EmailBody;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_emailSettings.EmailId, _emailSettings.Password);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                // Log Exception Details
                return false;
            }
        }

    }
}
