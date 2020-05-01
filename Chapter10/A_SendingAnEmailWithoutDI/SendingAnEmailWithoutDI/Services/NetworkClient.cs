using System;

namespace SendingAnEmailWithoutDI.Services
{
    public class NetworkClient
    {
        private readonly EmailServerSettings _settings;

        public NetworkClient(EmailServerSettings settings)
        {
            _settings = settings;
        }

        public void SendEmail(Email email)
        {
            Console.WriteLine($"Connecting to server {_settings.Host}:{_settings.Port}");
            Console.WriteLine($"Email sent to {email.Address}: {email.Message}");
        }
    }
}
