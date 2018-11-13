using CloudAPI.ApplicationCore.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace CloudAPI.ApplicationCore.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.APIKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            using (var client = new System.Net.Mail.SmtpClient())
            {
                var credential = new System.Net.NetworkCredential
                {
                    UserName = Options.From,
                    Password = Options.Password
                };

                client.Credentials = credential;
                client.Host = Options.Host;
                client.Port = int.Parse(Options.Port);
                client.EnableSsl = true;

                using (var emailMessage = new System.Net.Mail.MailMessage())
                {
                    emailMessage.To.Add(new System.Net.Mail.MailAddress(email));
                    emailMessage.From = new System.Net.Mail.MailAddress(Options.From);
                    emailMessage.Subject = subject;
                    emailMessage.Body = message;
                    emailMessage.IsBodyHtml = true;
                    client.Send(emailMessage);
                }
            }
            return Task.CompletedTask;

            //var client = new SendGridClient(apiKey);
            //var msg = new SendGridMessage()
            //{
            //    From = new EmailAddress(Options.From, Options.UserName),
            //    Subject = subject,
            //    PlainTextContent = message,
            //    HtmlContent = message
            //};
            //msg.AddTo(new EmailAddress(email));

            //// Disable click tracking.
            //// See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            //msg.SetClickTracking(false, false);

            //return client.SendEmailAsync(msg);
        }
    }
}