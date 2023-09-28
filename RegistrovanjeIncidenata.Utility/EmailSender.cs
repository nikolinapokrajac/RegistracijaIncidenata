using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using RegistrovanjeIncidenata.EmailService;
using System.Text;
using Message = Google.Apis.Gmail.v1.Data.Message;
//using System.Net.Mail;

namespace RegistrovanjeIncidenata.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly RegistrovanjeIncidenata.EmailService.EmailConfiguration _emailConfig;
        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            UserCredential credential = null;

            string[] scopes = { GmailService.Scope.GmailMetadata, GmailService.Scope.GmailSettingsSharing, GmailService.Scope.GmailSend, GmailService.Scope.GmailSettingsBasic, GmailService.Scope.GmailModify, GmailService.Scope.GmailReadonly };
            using (var stream = new FileStream("C:\\Users\\ASUS\\Downloads\\clientsecret\\client-secret.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.FromStream(stream).Secrets, scopes, "user", CancellationToken.None);
            }

            using (var gmailService = new GmailService(new BaseClientService.Initializer() { HttpClientInitializer = credential }))
            {
                var profile = gmailService.Users.GetProfile("me").Execute();
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress("Incident", _emailConfig.From));
                mimeMessage.To.Add(new MailboxAddress("Recipient", email));
                mimeMessage.Subject = subject;
                var textPart = new TextPart("html")
                {
                    Text = htmlMessage
                };
                var multipart = new Multipart("mixed");
                multipart.Add(textPart);
                mimeMessage.Body = multipart;
                var rawMessage = mimeMessage.ToString();
                byte[] inputBytes = Encoding.UTF8.GetBytes(rawMessage);
                string base64 = Convert.ToBase64String(inputBytes);
                string base64Url = base64.Replace('+', '-').Replace('/', '_');
                var message = new Message
                {
                    Raw = base64Url
                };
                var request = gmailService.Users.Messages.Send(message, "incident753@gmail.com");
                await request.ExecuteAsync();
            }
        }
    }
}

