using MailKit.Net.Smtp;
using MimeKit;

namespace SuperPoc.BuildingBlocks.Infrastructure.Mail;

public class MailService
{
    private readonly string _smtpServer;
    private readonly int _port;
    private readonly string _user;
    private readonly string _password;

    public MailService(string smtpServer, int port, string user, string password)
    {
        _smtpServer = smtpServer;
        _port = port;
        _user = user;
        _password = password;
    }

    public async Task SendMailAsync(string to, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("App", _user));
        message.To.Add(new MailboxAddress("", to));
        message.Subject = subject;
        message.Body = new TextPart("plain") { Text = body };

        using var client = new SmtpClient();
        await client.ConnectAsync(_smtpServer, _port, false);
        await client.AuthenticateAsync(_user, _password);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}