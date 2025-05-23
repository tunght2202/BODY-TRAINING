namespace BODYTRANINGAPI.Services.Emails
{
    public interface IGmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
