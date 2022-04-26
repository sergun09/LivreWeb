using Microsoft.AspNetCore.Identity.UI.Services;

namespace LivreWeb.Utilities;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        //TODO
        return Task.CompletedTask;
    }
}
