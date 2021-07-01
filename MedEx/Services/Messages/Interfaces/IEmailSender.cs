using System.Threading.Tasks;

namespace MedEx.Services.Messages.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
