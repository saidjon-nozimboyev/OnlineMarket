namespace OnlineMarket.Application.Interafces;

public interface IEmailService
{
    Task SendMessageToEmailAsync(string to, string title, string body);
}
