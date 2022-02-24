using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace KN.Messaging.SendGrid
{
    public class EmailSender : IEmailSender
    {
        private readonly string _apiKey;
        private readonly string _defaultSender;
        private readonly string _defaultSenderName;

        public EmailSender(string apiKey, string defaultSender = null, string defaultSenderName = null)
        {
            this._apiKey = apiKey;
            this._defaultSender = defaultSender;
            this._defaultSenderName = defaultSenderName;
        }

        public async Task<Response> Send(EmailMessage email)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress(email.From.EmailAddress, email.From.Name);
            var to = new EmailAddress(email.To.EmailAddress, email.To.Name);
            var subject = email.Subject;
            var plainTextContent = email.Content;
            var htmlContent = email.HtmlContent;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            try
            {
                var response = await client.SendEmailAsync(msg);
                return response;
            }
            catch (Exception)
            {
                //TODO: Log exception;
                throw;
            }
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress(_defaultSender, _defaultSenderName);
            var to = new EmailAddress(email);
            var htmlContent = htmlMessage;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            try
            {
                var response = await client.SendEmailAsync(msg);
            }
            catch (Exception)
            {
                //TODO: Log exception;
                throw;
            }
        }
    }
}
