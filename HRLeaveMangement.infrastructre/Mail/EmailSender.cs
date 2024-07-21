using HRLeaveMangement.Application.Contracts.infrastructre;
using HRLeaveMangement.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.infrastructre.Mail
{
    public class EmailSender : IEmailSender
    {
        private  EmailSettings _emailSettings { get; }

        public EmailSender(IOptions<EmailSettings>  emailSettings)
        {
           _emailSettings = emailSettings.Value;
        }
        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var To = new EmailAddress(email.To);
            var From = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name =_emailSettings.FromName,
            };

            var message = MailHelper.CreateSingleEmail(From, To,email.Subject,email.body,email.body);

            var response = await client.SendEmailAsync(message);
            return response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted;
        }
    }
}
