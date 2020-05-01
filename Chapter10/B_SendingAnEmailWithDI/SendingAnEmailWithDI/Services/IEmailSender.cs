namespace SendingAnEmailWithoutDI.Services
{
    public interface IEmailSender
    {
        void SendEmail(string username);
    }
}
