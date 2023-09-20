using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.IdentityModel.Tokens;
//using System.Net.Mail;
using MimeKit;
using paAjmoPokusat.EmailService;
using System.Text;

namespace paAjmoPokusat.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly paAjmoPokusat.EmailService.EmailConfiguration _emailConfig;
        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
            {
                ClientId = "689151936674-oik1sbmianfrhrq22o5l24jv48f174f9.apps.googleusercontent.com",
                ClientSecret = "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"
            },
                new[] { GmailService.Scope.GmailCompose },
                "user",
                CancellationToken.None);
            var gmailService = new GmailService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "App"
            });
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Sender Name", _emailConfig.From));
            emailMessage.To.Add(new MailboxAddress("Receiver Name", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };
            var message = new Google.Apis.Gmail.v1.Data.Message
            {
                Raw = Base64UrlEncoder.Encode(Encoding.UTF8.GetBytes(emailMessage.ToString())),
            };
            var result = await gmailService.Users.Messages.Send(message, "me").ExecuteAsync();

        }
        //public Task SendEmailAsync(string email, string subject, string message)
        //{
        //    var mail = "incident753@gmail.com";
        //    var pw = "Zaporka123";
        //    var client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
        //    {
        //        EnableSsl = true,
        //        Credentials = new System.Net.NetworkCredential(mail, pw)
        //    };

        //    var mailMessage = new MailMessage(mail, email, subject, message); // Provide an empty string as the body

        //    return client.SendMailAsync(mailMessage);
        //}


    }
}

