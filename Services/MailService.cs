﻿using System.Diagnostics;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace Crito.Services
{
    public class MailService : IDisposable
    {
        private readonly string _from;
        private readonly string _smtp;
        private readonly int _port;
        private readonly string _username;
        private readonly string _password;
        private readonly SmtpClient _client;

        public MailService(string from, string smtp, int port, string username, string password)
        {
            _from = from;
            _smtp = smtp;
            _port = port;
            _username = username;
            _password = password;
            _client = new SmtpClient();
        }

        public async Task SendAsync(string to, string subject, string body)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_from));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = subject;
                email.Body=new TextPart(TextFormat.Html) { Text = body };

                await _client.ConnectAsync(_smtp,_port,SecureSocketOptions.StartTls);
                await _client.AuthenticateAsync(_username,_password);

                var result = await _client.SendAsync(email);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }
}