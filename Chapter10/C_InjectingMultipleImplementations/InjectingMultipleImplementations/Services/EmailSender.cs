using System;

namespace InjectingMultipleServices.Services
{
    public class EmailSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Sending Email message: {message}");
        }
    }
}
