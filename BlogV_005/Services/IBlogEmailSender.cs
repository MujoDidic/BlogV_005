using Microsoft.AspNetCore.Identity.UI.Services;

namespace BlogV_005.Services
{
    public interface IBlogEmailSender : IEmailSender
    {
        Task SendContactEmailAsync(string emailFrom, string name, string subject, string htmlMessage );
    }
}
