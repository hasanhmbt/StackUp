using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

public class EmailService
{
    private readonly EmailConfiguration _emailConfig;

    public EmailService(IOptions<EmailConfiguration> emailConfig)
    {
        _emailConfig = emailConfig.Value;
    }

    public async Task SendEmailAsync(string recipientEmail, string subject, string body)
    {
        try
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emailConfig.DisplayName, _emailConfig.From));
            message.To.Add(new MailboxAddress("", recipientEmail));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = body };
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, MailKit.Security.SecureSocketOptions.StartTls);

                await client.AuthenticateAsync(_emailConfig.Username, _emailConfig.Password);

                await client.SendAsync(message);

                await client.DisconnectAsync(true);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public class EmailConfiguration
    {
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
    }

}
