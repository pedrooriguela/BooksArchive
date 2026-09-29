namespace MoviesArchive.Domain.Interfaces;

public interface IEmailService
{
    Task Send(string toEmail, string subject, string body);
}